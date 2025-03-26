using EinvoiceIntegration.Models.B2C.OfflineAPI;
using EinvoiceIntegration.Services.B2C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers.B2C
{
    public class B2CInvoiceQueryOfflineMerchantPosSettingController : Controller
    {
        // GET: B2CInvoiceQueryOfflineMerchantPosSetting
        public ActionResult Index()
        {
            return View(new QueryOfflineMerchantPosSettingModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(QueryOfflineMerchantPosSettingModel model)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.QueryOfflineMerchantPosSetting,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<QueryOfflineMerchantPosSettingModel, QueryOfflineMerchantPosSettingResult>(model);

            return View();
        }
    }
}