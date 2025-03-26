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
            return View();
        }

        [HttpPost]
        public ActionResult Index(InvoiceInvalid invalid)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.Invalid,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            var model = new InvalidModel
            {
                MerchantID = invalid.MerchantID,
                InvoiceDate = invalid.InvoiceDate,
                InvoiceNo = invalid.InvoiceNo,
                Reason = invalid.Reason
            };

            ViewBag.Message = _service.PostRtnJson<InvalidModel, InvalidResult>(model);

            return View();
        }
    }
}