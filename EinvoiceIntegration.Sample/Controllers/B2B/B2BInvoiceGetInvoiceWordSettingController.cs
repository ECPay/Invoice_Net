using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2BInvoiceGetInvoiceWordSettingController : Controller
    {
        // GET: B2BInvoiceGetInvoiceWordSetting
        public ActionResult Index()
        {
            return View(new GetInvoiceWordSettingModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetInvoiceWordSettingModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.GetInvoiceWordSetting,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<GetInvoiceWordSettingModel, GetInvoiceWordSettingResult>(model);

            return View();
        }
    }
}