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
            return View();
        }

        [HttpPost]
        public ActionResult Index(InvoiceInvalid invalid)
        {
            var service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.Invalid,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            var model = new InvoiceInvalidModel
            {
                MerchantID = invalid.MerchantID,
                InvoiceDate = invalid.InvoiceDate,
                InvoiceNumber = invalid.InvoiceNumber,
                Reason = invalid.Reason,
                Remark = invalid.Remark
            };

            ViewBag.Message = service.PostRtnJson<InvoiceInvalidModel, InvoiceInvalidResult>(model);

            return View();
        }
    }
}