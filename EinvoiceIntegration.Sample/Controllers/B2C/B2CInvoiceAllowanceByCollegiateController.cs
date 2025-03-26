using EinvoiceIntegration.Models.B2C;
using EinvoiceIntegration.Services.B2C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2CInvoiceAllowanceByCollegiateController : Controller
    {
        // GET: B2CInvoiceAllowanceByCollegiate
        public ActionResult Index()
        {
            return View(new AllowanceByCollegiateModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public string Allowance(AllowanceByCollegiateModel model)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.AllowanceByCollegiate,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            return _service.PostRtnJson<AllowanceByCollegiateModel, AllowanceByCollegiateResult>(model);
        }
    }
}