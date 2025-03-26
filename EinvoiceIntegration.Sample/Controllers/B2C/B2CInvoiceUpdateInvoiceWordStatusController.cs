using EinvoiceIntegration.Models.B2C;
using EinvoiceIntegration.Services.B2C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers.B2C
{
    public class B2CInvoiceUpdateInvoiceWordStatusController : Controller
    {
        // GET: B2CInvoiceUpdateInvoiceWordStatus
        public ActionResult Index()
        {
            return View(new UpdateInvoiceWordStatusModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(UpdateInvoiceWordStatusModel model)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.UpdateInvoiceWordStatus,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<UpdateInvoiceWordStatusModel, UpdateInvoiceWordStatusResult>(model);

            return View();
        }
    }
}