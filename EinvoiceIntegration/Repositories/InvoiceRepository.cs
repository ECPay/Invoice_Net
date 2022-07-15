using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EinvoiceIntegration.Repositories
{
    public class InvoiceRepository
    {
        public IDictionary<string, string> headers { get; set; }

        public string CallApi(string url, string data)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string result = string.Empty;
            byte[] byContent = Encoding.UTF8.GetBytes(data);

            WebRequest webRequest = WebRequest.Create(url);
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach(var key in headers.Keys)
                    {
                        webRequest.Headers.Add(key, headers[key]);
                    }
                }

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
                            result = oReader.ReadToEnd().Trim();
                        }
                    }

                    webResponse.Close();
                    webResponse = null;
                }

                webRequest = null;
            }

            return result;
        }

        #region 私用方法
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        #endregion
    }
}
