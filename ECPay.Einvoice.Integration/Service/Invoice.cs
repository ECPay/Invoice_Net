using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Ecpay.EInvoice.Integration.Attributes;
using Ecpay.EInvoice.Integration.Enumeration;
using Ecpay.EInvoice.Integration.Interface;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Ecpay.EInvoice.Integration.Service
{
    /// <summary>
    /// 操作發票各功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Invoice<T> : IDisposable
    {
        /// <summary>
        /// initial, 供內部測試注入 apimodel 使用
        /// </summary>
        /// <param name="obj"></param>
        internal Invoice(IApiUrlModel apimodel)
        {
            this.Iapi = apimodel;
        }

        /// <summary>
        /// initial
        /// </summary>
        /// <param name="obj"></param>
        public Invoice()
        {
            this.Iapi = new ApiUrlModel();
        }

        /// <summary>
        /// 開始執行發票功能, 並取得結果
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string post(T obj)
        {
            _Iinv = obj as Iinvoice;

            //先作驗證
            string Valid = Validate(obj);

            if (!string.IsNullOrEmpty(Valid))
                return Valid;

            //組出傳送字串
            ObjectToNameValueCollection(obj);

            //取出API位置
            ApiUrl url = Iapi.getlist().Where(p => p.invM == _Iinv.invM && p.env == Environment).FirstOrDefault();

            //作壓碼字串
            string checkmacvalue = BuildCheckMacValue(this._parameters);

            //組出實際傳送的字串
            string urlstring = string.Format("{0}&{1}", this._parameters, "CheckMacValue=" + checkmacvalue);

            //執行api功能, 並取得回傳結果
            string result = ServerPost(urlstring, url.apiUrl);

            return validReturnString(result);
        }

        #region - Public 屬性欄位成員

        /// <summary>
        /// 介接的 HashKey。
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string HashKey { get; set; }

        /// <summary>
        /// 介接的 HashIV。
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string HashIV { get; set; }

        /// <summary>
        /// 執行環境
        /// Stage -- 測試
        /// Prod -- 正式
        /// </summary>
        public EnvironmentEnum Environment
        {
            get
            {
                return _environment;
            }
            set
            {
                _environment = value;
            }
        }

        #endregion - Public 屬性欄位成員

        #region - Private 屬性欄位成員

        /// <summary>
        /// 廠商驗證時間(自動產生)。
        /// </summary>
        private EnvironmentEnum _environment = EnvironmentEnum.Stage;

        /// <summary>
        /// 代入API的 Iinvoice 介面
        /// </summary>
        private Iinvoice _Iinv;

        /// <summary>
        /// 各API位置的資料參考介面
        /// </summary>
        private IApiUrlModel Iapi;

        /// <summary>
        /// 將輸入的物件各參數轉為 namevalue collection 字串
        /// </summary>
        private string _parameters = string.Empty;

        /// <summary>
        /// 不加入驗證的參數
        /// </summary>
        private string[] IgnoreMacValues = { "CHECKMACVALUE", "ITEMNAME", "ITEMWORD", "REASON", "INVOICEREMARK", "SPECSOURCE", "ITEMREMARK", "POSBARCODE", "QRCODE_LEFT", "QRCODE_RIGHT" };

        #endregion - Private 屬性欄位成員

        #region - 私用方法

        /// <summary>
        /// 驗證欄位並傳回字串
        /// </summary>
        /// <param name="obj">傳入需驗證的物件</param>
        /// <returns>回傳驗證後訊息</returns>
        private string Validate(T obj)
        {
            StringBuilder Result = new StringBuilder();
            List<string> errList = new List<string>();

            errList.AddRange(ServerValidator.Validate(obj));

            if (errList.Count > 0)
            {
                foreach (var item in errList)
                {
                    Result.Append(item.ToString() + " ");
                }
            }
            return Result.ToString();
        }

        /// <summary>
        /// 產生物件的參數字串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private void ObjectToNameValueCollection(T obj)
        {
            Type elemType = obj.GetType();
            string value = string.Empty;
            object attr = null;

            //取出物件的原型
            foreach (PropertyInfo item in elemType.GetProperties(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance)
                //.Where(x => !x.GetCustomAttributes(typeof(NonProcessValueAttribute),true).Any())
                .OrderBy(i => i.Name))
            {
                //如果Attribute有設定不處理就直接跳過
                attr = item.GetCustomAttributes(typeof(NonProcessValueAttribute), true).FirstOrDefault();
                if (attr != null)
                    continue;

                try
                {
                    if (item.PropertyType.IsEnum) //Enum
                    {
                        int enumVlue = (int)Enum.Parse(item.PropertyType, item.GetValue(obj, null).ToString());
                        value = enumVlue.ToString();
                    }
                    else if (item.PropertyType.IsClass && item.PropertyType.IsSerializable) //String
                        value = (string)item.GetValue(obj, null) ?? "";
                    else if (item.PropertyType.IsValueType && item.PropertyType.IsSerializable && !item.PropertyType.IsEnum) //Int
                        value = item.GetValue(obj, null).ToString();
                    //else if (item.PropertyType.IsGenericType && typeof(ICollection<>).IsAssignableFrom(item.PropertyType.GetGenericTypeDefinition()) ||
                    //        item.PropertyType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>)))
                    //    continue;
                    else //本來要排除 Itemcollection, 不過上面的排除方法太費工, 所以改成找不到的就當作是 Itemcollection
                        continue;
                }
                catch
                {
                    throw new Exception("Failed to set property value for our Foreign Key");
                }

                // 特定 Attribute 不作Encode
                attr = item.GetCustomAttributes(typeof(NeedEncodeAttribute), true).FirstOrDefault();
                if (attr != null)
                    value = HttpUtility.UrlEncode(value);

                // 特定 Attribute 需要Replace
                attr = item.GetCustomAttributes(typeof(NeedReplaceAttribute), true).FirstOrDefault();
                if (attr != null)
                    value = value.ToString().Replace('+', ' ');

                if (string.IsNullOrEmpty(_parameters))
                    _parameters = String.Format("{0}={1}", item.Name, value);
                else
                    _parameters += String.Format("&{0}={1}", item.Name, value);
            }
        }

        /// <summary>
        /// 產生檢查碼。
        /// 並排除不作驗證的字串
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string BuildCheckMacValue(string param)
        {
            //排除不作驗證的字串
            string urlparams = RemoveIgnoreMacValues(param);
            // 產生檢查碼。
            string szCheckMacValue = String.Empty;
            szCheckMacValue = String.Format("HashKey={0}&{1}&HashIV={2}", this.HashKey, urlparams, this.HashIV);
            //saveLog("傳送字串Encode前:" + szCheckMacValue);
            szCheckMacValue = HttpUtility.UrlEncode(szCheckMacValue).ToLower();
            //saveLog("傳送字串Encode後:" + szCheckMacValue);
            szCheckMacValue = MD5Encoder.Encrypt(szCheckMacValue);
            return szCheckMacValue;
        }

        /// <summary>
        /// 驗證回傳字串，並回覆結果字串
        /// </summary>
        /// <param name="returnString"></param>
        /// <returns>Json格式的字串</returns>
        private string validReturnString(string returnString)
        {
            //整理回傳結果
            NameValueCollection nvc = HttpUtility.ParseQueryString(returnString);
            //取出結果及驗證碼
            string RtnCode = nvc["RtnCode"].ToString();
            string checkMacValue = nvc["CheckMacValue"];
            //saveLog("結果:" + returnString);

            //回傳成功的資訊, 如果回覆成功就比對驗證碼確認資料正確
            if (RtnCode == "1")
            {
                string returnBuildCheckMacValue = BuildCheckMacValue(returnString);
                //saveLog("自己產生的驗證字串:" + returnBuildCheckMacValue);
                if (checkMacValue != returnBuildCheckMacValue)
                {
                    nvc["RtnCode"] = "1000001";
                    nvc["RtnMsg"] = "計算回傳檢核碼失敗";
                }
            }

            return JsonConvert.SerializeObject(nvc.AllKeys.ToDictionary(x => x, y => nvc[y]));
        }

        /// <summary>
        /// 將輸入的URL String 字串, 排除不加入驗證規則的參數
        /// </summary>
        /// <param name="urlstring"></param>
        /// <returns></returns>
        private string RemoveIgnoreMacValues(string urlstring)
        {
            //Regex regex = new Regex("(?<Key>[^= ]+)\\s*=\\s*\"(?<Value>[^\"]+)\"\\s+");
            string regexExam = @"([^=|^\&]+)\=([^\&]+)?";
            Regex regex = new Regex(regexExam);
            MatchCollection matches = regex.Matches(urlstring);

            NameValueCollection nvc = new NameValueCollection();
            foreach (Match m in matches)
            {
                string[] kv = m.Value.ToString().Split('=');
                string key = kv[0];
                string value = kv[1];
                if (key.ToUpper() == "IIS_CARRUER_NUM") value = value.Replace('+', ' ');
                if (!IgnoreMacValues.Contains(key.ToUpper()))
                    nvc.Add(key, value);
            }
            string param = string.Join("&", nvc.AllKeys.OrderBy(key => key).Select(key => key + "=" + nvc[key]).ToArray());
            return param;
        }

        /// <summary>
        /// 伺服器端傳送參數請求資料。
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="apiURL"></param>
        /// <returns></returns>
        private string ServerPost(string parameters, string apiURL)
        {
            string szResult = String.Empty;
            byte[] byContent = Encoding.UTF8.GetBytes(parameters);

            //saveLog("實際字串:" + parameters);
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2;

            WebRequest webRequest = WebRequest.Create(apiURL);
            {
                webRequest.Credentials = CredentialCache.DefaultCredentials;

                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                webRequest.ContentLength = byContent.Length;

                using (System.IO.Stream oStream = webRequest.GetRequestStream())
                {
                    oStream.Write(byContent, 0, byContent.Length); //Push it out there
                    oStream.Close();
                }

                WebResponse webResponse = webRequest.GetResponse();
                {
                    if (null != webResponse)
                    {
                        using (StreamReader oReader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            szResult = oReader.ReadToEnd().Trim();
                        }
                    }

                    webResponse.Close();
                    webResponse = null;
                }

                webRequest = null;
            }

            return szResult;
        }

        /// <summary>
        /// 紀錄參數 DeBug 用
        /// </summary>
        /// <param name="requestForm"></param>
        /// <param name="logType"></param>
        private void saveLog(string str)
        {
            string fileName = "c://" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("QueryString:").Append(str).AppendLine();
            fileContent.Append("Log建立時間:").Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).AppendLine();
            fileContent.AppendLine();

            System.IO.File.AppendAllText(fileName, fileContent.ToString());
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        #endregion - 私用方法

        #region - 釋放使用資源

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            GC.Collect(); ;
        }

        #endregion - 釋放使用資源
    }
}