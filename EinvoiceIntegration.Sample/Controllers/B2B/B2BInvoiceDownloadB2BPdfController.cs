using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers.B2B
{
    public class B2BInvoiceDownloadB2BPdfController : Controller
    {
        // GET: B2BInvoiceDownloadB2BPdf
        public ActionResult Index()
        {
            return View(new DownloadB2BPdfModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(DownloadB2BPdfModel model, string rootDictionary)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.DownloadB2BPdf,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            string defaultRootDictionary = "D:\\Download";
            string saveDictionary = string.IsNullOrEmpty(rootDictionary) ? defaultRootDictionary : rootDictionary;
            string filePath;
            using (var webResponse = _service.CallApiGetResponse<DownloadB2BPdfModel>(model))
            {
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    string contentDisposition = webResponse.Headers["Content-Disposition"];
                    string contentType = webResponse.ContentType;
                    string fileName = $"defaultFileName_{DateTime.Now.ToString("yyyyMMddHHmmss")}";

                    if (!string.IsNullOrEmpty(contentDisposition))
                    {
                        // 嘗試從 Content-Disposition 解析檔名
                        var match = System.Text.RegularExpressions.Regex.Match(contentDisposition, @"filename=""?([^"";]+)""?");
                        if (match.Success)
                        {
                            fileName = match.Groups[1].Value;
                        }
                    }
                    else
                    {
                        // 無法取得檔名，根據 ContentType 給預設副檔名
                        fileName += GetFileExtensionFromContentType(contentType);
                    }

                    filePath = Path.Combine(saveDictionary, fileName);

                    if (!Directory.Exists(saveDictionary))
                    {
                        Directory.CreateDirectory(saveDictionary);
                    }
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }

            ViewBag.Message = $"下載完畢，檔案存放路徑：{filePath}";

            return View();
        }

        private string GetFileExtensionFromContentType(string contentType)
        {
            var ContentTypeToExtensionMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "application/pdf", ".pdf" },
                { "application/json", ".json" },
                { "text/plain", ".txt" },
                { "text/html", ".html" },
                { "application/xml", ".xml" },
                { "image/jpeg", ".jpg" },
                { "image/png", ".png" },
            };

            var mainContentType = contentType.Split(';')[0].Trim();
            if (ContentTypeToExtensionMap.TryGetValue(mainContentType, out string extension))
            {
                return extension;
            }

            return string.Empty;
        }
    }
}