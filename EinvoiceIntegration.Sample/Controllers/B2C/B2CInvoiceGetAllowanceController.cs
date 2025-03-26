using EinvoiceIntegration.Models.B2C;
using EinvoiceIntegration.Services.B2C;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2CInvoiceGetAllowanceController : Controller
    {
        // GET: B2CInvoiceGetAllowance
        public ActionResult Index()
        {
            return View(new GetAllowanceModel() { MerchantID = 2000132 });
        }

        [HttpPost]
        public ActionResult Index(GetAllowanceModel model)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.GetAllowance,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            ViewBag.Message = _service.PostRtnJson<GetAllowanceModel, GetAllowanceResult>(model);
            return View();
        }
    }
}