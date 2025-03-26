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
    public class B2BInvoiceNotifyController : Controller
    {
        // GET: B2BInvoiceNotify
        public ActionResult Index()
        {
            return View(new NotifyModel() { MerchantID = 2000132, InvoiceTag = 1 });
        }

        [HttpPost]
        public ActionResult Index(NotifyModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.Notify,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<NotifyModel, NotifyResult>(model);
            return View();
        }
    }
}