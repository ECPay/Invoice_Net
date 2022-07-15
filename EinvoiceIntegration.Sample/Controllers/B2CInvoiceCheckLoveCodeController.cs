using EinvoiceIntegration.Models.B2C;
using EinvoiceIntegration.Services.B2C;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2CInvoiceCheckLoveCodeController : Controller
    {
        // GET: B2CInvoiceCheckLoveCode
        public ActionResult Index()
        {
            //範例View
            return View(new CheckLoveCodeModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(CheckLoveCodeModel model)
        {
            //1. 設定檢查愛心碼資訊(此範例由View傳入model所需資訊)

            //2. 初始化發票Service物件
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,               //指定測試環境, 上線時請記得改為Prod
                B2CEnum = Enum.B2C.B2CInvoiceMethod.CheckLoveCode,  //指定呼叫的API
                HashKey = "ejCk326UnaZWKisg",                       //設定綠界提供的Key
                HashIV = "q9jcZX8Ib9LM8wYk"                         //設定綠界提供的IV
            };

            //3. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            ViewBag.Message = _service.PostRtnJson<CheckLoveCodeModel, CheckLoveCodeResult>(model);
            return View();
        }
    }
}