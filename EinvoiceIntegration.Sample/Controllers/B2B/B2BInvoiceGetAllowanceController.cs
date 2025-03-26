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
    public class B2BInvoiceGetAllowanceController : Controller
    {
        // GET: B2BInvoiceGetAllowance
        public ActionResult Index()
        {
            return View(new GetAllowanceModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetAllowanceModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.GetAllowance,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };
            ViewBag.Message = _service.PostRtnJson<GetAllowanceModel, GetAllowanceResult>(model);
            return View();
        }
    }
}