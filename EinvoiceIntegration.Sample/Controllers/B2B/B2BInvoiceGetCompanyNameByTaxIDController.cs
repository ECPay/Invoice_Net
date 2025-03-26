using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers.B2B
{
    public class B2BInvoiceGetCompanyNameByTaxIDController : Controller
    {
        // GET: B2BInvoiceGetCompanyNameByTaxID
        public ActionResult Index()
        {
            return View(new GetCompanyNameByTaxIDModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetCompanyNameByTaxIDModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                //B2BEnum = Enum.B2B.B2BInvoiceMethod.GetCompanyNameByTaxID,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<GetCompanyNameByTaxIDModel, GetCompanyNameByTaxIDResult>(model);

            return View();
        }
    }
}