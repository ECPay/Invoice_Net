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
    public class B2BInvoiceGetIssueConfirmController : Controller
    {
        // GET: B2BInvoiceGetIssueConfirm
        public ActionResult Index()
        {
            return View(new GetIssueModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetIssueModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.GetIssueConfirm,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<GetIssueModel, GetIssueResult>(model);
            return View();
        }
    }
}