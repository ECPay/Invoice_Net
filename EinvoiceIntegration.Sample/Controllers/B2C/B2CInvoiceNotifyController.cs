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
    public class B2CInvoiceNotifyController : Controller
    {
        // GET: B2CInvoiceNotify
        public ActionResult Index()
        {
            return View(new NotifyModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(NotifyModel model)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.InvoiceNotify,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<NotifyModel, NotifyResult>(model);
            return View();
        }
    }
}