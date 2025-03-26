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
    public class B2BInvoiceRejectConfirmController : Controller
    {
        // GET: B2BInvoiceRejectConfirm
        public ActionResult Index()
        {
            return View(new RejectConfirmModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(RejectConfirmModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.RejectConfirm,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<RejectConfirmModel, RejectConfirmResult>(model);
            return View();
        }
    }
}