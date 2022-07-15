using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2BInvoiceGetAllowanceConfirmController : Controller
    {
        // GET: B2BInvoiceGetAllowanceConfirm
        public ActionResult Index()
        {
            //範例View
            return View(new GetAllowanceModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetAllowanceModel model)
        {
            //1. 設定查詢折讓發票確認資訊(此範例由View傳入model所需資訊)

            //2. 初始化發票Service物件
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,                   //指定測試環境, 上線時請記得改為Prod
                B2BEnum = Enum.B2B.B2BInvoiceMethod.GetAllowanceConfirm,//指定呼叫的API
                HashKey = "ejCk326UnaZWKisg",                           //設定綠界提供的Key
                HashIV = "q9jcZX8Ib9LM8wYk"                             //設定綠界提供的IV
            };

            //3. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            ViewBag.Message = _service.PostRtnJson<GetAllowanceModel, GetAllowanceResult>(model);
            return View();
        }
    }
}