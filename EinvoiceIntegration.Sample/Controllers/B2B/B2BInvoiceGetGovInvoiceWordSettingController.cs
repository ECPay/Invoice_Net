using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers.B2B
{
    public class B2BInvoiceGetGovInvoiceWordSettingController : Controller
    {
        // GET: B2BInvoiceGetGovInvoiceWordSetting
        public ActionResult Index()
        {
            return View(new GetGovInvoiceWordSettingModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetGovInvoiceWordSettingModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.GetGovInvoiceWordSetting,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<GetGovInvoiceWordSettingModel, GetGovInvoiceWordSettingResult>(model);

            return View();
        }
    }
}