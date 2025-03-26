using EinvoiceIntegration.Models.B2B;
using EinvoiceIntegration.Services.B2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers.B2B
{
    public class B2BInvoicePrintController : Controller
    {
        // GET: B2BInvoicePrintController
        public ActionResult Index()
        {
            return View(new InvoicePrintModel() { MerchantID = 3089976 });
        }

        [HttpPost]
        public ActionResult Index(InvoicePrintModel model)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Dev,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.InvoicePrint,
                HashKey = "K8dZeuJUp3Qt67Bc",
                HashIV = "j83wrQWXC4c3mdPc"
            };

            ViewBag.Message = _service.Post<InvoicePrintModel>(model);

            return View();
        }
    }
}