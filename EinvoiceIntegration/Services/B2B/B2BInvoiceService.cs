using EinvoiceIntegration.Enum;
using EinvoiceIntegration.Enum.B2B;
using EinvoiceIntegration.Interfaces;
using EinvoiceIntegration.Models;
using EinvoiceIntegration.Repositories;
using EinvoiceIntegration.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EinvoiceIntegration.Services.B2B
{
    public class B2BInvoiceService
    {
        public B2BInvoiceService()
        {
            this.IApi = new ApiUrlModel();
        }

        private IApiUrlModel IApi;

        private EnvironmentEnum _Env;
        public EnvironmentEnum EnvEnum
        {
            get { return _Env; }
            set { _Env = value; }
        }

        private B2BInvoiceMethod _B2B;
        public B2BInvoiceMethod B2BEnum
        {
            get { return _B2B; }
            set { _B2B = value; }
        }

        public string HashKey { get; set; }

        public string HashIV { get; set; }

        public IDictionary<string, string> headers { get; set; }

        long GetTimestamp { get { return ConvertHelper.Date2Timespan(DateTime.Now) / 1000; } }

        string GetRevision { get { return "1.0.0"; } }

        string GetRqID { get { return Guid.NewGuid().ToString(); } }

        /// <summary>
        /// post
        /// </summary>
        /// <typeparam name="T">來源型態</typeparam>
        /// <param name="obj">來源</param>
        /// <param name="PlatformID">平台商ID</param>
        /// <param name="IsCheckModel">是否檢查model</param>
        /// <returns></returns>
        public string PostRtnJson<T, S>(T obj, long PlatformID = 0, bool IsCheckModel = true)
            where T : BaseModel
            where S : BaseResult, new()
        {
            var result = new SdkResult<S>();
            if (IsCheckModel)
            {
                string errorMsg = string.Empty;
                var IsValid = new Validate().IsValid(obj, ref errorMsg);
                if (!IsValid)
                {
                    result.PlatformID = PlatformID;
                    result.MerchantID = obj.MerchantID;
                    result.RpHeader = new ApiHeaderModel() { Revision = GetRevision, Timestamp = GetTimestamp, RqID = GetRqID };
                    result.TransCode = 0;
                    result.Data = new S
                    {
                        RtnCode = 0,
                        RtnMsg = errorMsg
                    };
                    return JsonConvert.SerializeObject(result);
                }
            }

            result = _Post<T, S>(obj, PlatformID);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// Post 回傳物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="PlatformID"></param>
        /// <param name="IsCheckModel"></param>
        /// <returns></returns>
        public SdkResult<S> Post<T, S>(T obj, long PlatformID = 0, bool IsCheckModel = true)
            where T : BaseModel
            where S : BaseResult, new ()
        {
            var result = new SdkResult<S>();
            if (IsCheckModel)
            {
                string errorMsg = string.Empty;
                var IsValid = new Validate().IsValid(obj, ref errorMsg);
                if (!IsValid)
                {
                    result.PlatformID = PlatformID;
                    result.MerchantID = obj.MerchantID;
                    result.RpHeader = new ApiHeaderModel() { Revision = GetRevision, Timestamp = GetTimestamp, RqID = GetRqID };
                    result.TransCode = 0;
                    result.Data = new S
                    {
                        RtnCode = 0,
                        RtnMsg = errorMsg
                    };
                    return result;
                }
            }

            result = _Post<T, S>(obj, PlatformID);
            return result;
        }

        /// <summary>
        /// post共用物件
        /// </summary>
        /// <typeparam name="T">來源</typeparam>
        /// <param name="obj">來源model</param>
        /// <param name="PlatformID">平台商編號</param>
        /// <returns></returns>
        SdkResult<S> _Post<T, S>(T obj, long PlatformID = 0)
            where T : BaseModel
        {
            var _repository = new InvoiceRepository { headers = headers };

            var urlModel = IApi.GetList().Where(t => t.Category == EinvoiceCategory.B2B && t.env == EnvEnum).FirstOrDefault();

            string apiUrl = string.Format("{0}/{1}", urlModel.apiUrl, B2BEnum.ToString());

            AESProvider crypt = new AESProvider();
            string temp = JsonConvert.SerializeObject(obj);
            var encryptData = crypt.AES_EnCrypt(HashKey, HashIV, HttpUtility.UrlEncode(JsonConvert.SerializeObject(obj)));

            var data = JsonConvert.SerializeObject(new
            {
                PlatformID,
                obj.MerchantID,
                RqHeader = new
                {
                    Timestamp = GetTimestamp,
                    RqID = GetRqID,
                    Revision = GetRevision
                },
                Data = encryptData
            });

            var responeData = _repository.CallApi(apiUrl, data);
            var apiResult = JsonConvert.DeserializeObject<ApiRpModel>(responeData);

            var result = new SdkResult<S>
            {
                PlatformID = apiResult.PlatformID,
                MerchantID = apiResult.MerchantID,
                RpHeader = apiResult.RpHeader,
                TransCode = apiResult.TransCode,
                TransMsg = apiResult.TransMsg
            };

            try
            {
                if (apiResult.Data != null)
                    result.Data = JsonConvert.DeserializeObject<S>(HttpUtility.UrlDecode(crypt.AES_DeCrypt(HashKey, HashIV, apiResult.Data)));
            }
            catch { }
            return result;
        }
    }
}
