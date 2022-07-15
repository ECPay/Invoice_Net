using EinvoiceIntegration.Models.B2C;
using EinvoiceIntegration.Sample.Models.B2C;
using EinvoiceIntegration.Services.B2C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2CInvoiceInvalidController : Controller
    {
        // GET: B2CInvoiceInvalid
        public ActionResult Index()
        {
            //範例View
            return View();
        }

        [HttpPost]
        public ActionResult Index(InvoiceInvalid invalid)
        {
            //1. 設定發票作廢資訊(此範例由View傳入model所需資訊)

            //2. 初始化發票Service物件
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.Invalid,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            //3. 轉換為SDK提供的model
            var model = new InvalidModel
            {
                MerchantID = invalid.MerchantID,
                InvoiceDate = invalid.InvoiceDate,
                InvoiceNo = invalid.InvoiceNo,
                Reason = invalid.Reason
            };

            //4. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            ViewBag.Message = _service.PostRtnJson<InvalidModel, InvalidResult>(model);

            return View();
        }
    }
}