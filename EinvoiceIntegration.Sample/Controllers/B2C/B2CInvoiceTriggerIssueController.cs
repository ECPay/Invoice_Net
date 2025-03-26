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
    public class B2CInvoiceTriggerIssueController : Controller
    {
        // GET: B2CInvoiceTriggerIssue
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(InvoiceTriggerIssue triggerIssue)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.TriggerIssue,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            var model = new TriggerIssueModel
            {
                MerchantID = triggerIssue.MerchantID,
                PayTypeEnum = triggerIssue.PayType,
                Tsr = triggerIssue.Tsr
            };

            ViewBag.Message = _service.PostRtnJson<TriggerIssueModel, TriggerIssueResult>(model);

            return View();
        }
    }
}