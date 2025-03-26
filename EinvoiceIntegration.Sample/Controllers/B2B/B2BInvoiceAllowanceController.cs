using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2BInvoiceAllowanceController : Controller
    {
        // GET: B2BInvoiceAllowance
        public ActionResult Index()
        {
            return View(new AllowanceModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public string Allowance(AllowanceModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.Allowance,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            return _service.PostRtnJson<AllowanceModel, AllowanceResult>(model);
        }
    }
}