using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Sample.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2BInvoiceInvalidController : Controller
    {
        // GET: B2BInvoiceInvalid
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
            var service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,       //指定測試環境, 上線時請記得改為Prod
                B2BEnum = Enum.B2B.B2BInvoiceMethod.Invalid,//指定呼叫的API
                HashKey = "ejCk326UnaZWKisg",               //設定綠界提供的Key
                HashIV = "q9jcZX8Ib9LM8wYk"                 //設定綠界提供的IV
            };

            //3. 轉換為SDK提供的model
            var model = new InvoiceInvalidModel
            {
                MerchantID = invalid.MerchantID,
                InvoiceDate = invalid.InvoiceDate,
                InvoiceNumber = invalid.InvoiceNumber,
                Reason = invalid.Reason,
                Remark = invalid.Remark
            };

            //4. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            ViewBag.Message = service.PostRtnJson<InvoiceInvalidModel, InvoiceInvalidResult>(model);

            return View();
        }
    }
}