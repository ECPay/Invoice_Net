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
    public class B2BInvoiceIssueController : Controller
    {
        // GET: B2BInvoiceIssue
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string InvoiceIssue(InvoiceIssue issue)
        {
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2BEnum = Enum.B2B.B2BInvoiceMethod.Issue,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            int seqNumber = 0;
            var items = new List<InvoiceIssueModel.Item>();
            issue.Items.ForEach(t => items.Add(new InvoiceIssueModel.Item
            {
                ItemSeq = seqNumber + 1,
                ItemName = t.ItemName,
                ItemCount = t.ItemCount,
                ItemTax = t.ItemTax,
                ItemWord = t.ItemWord,
                ItemPrice = t.ItemPrice,
                ItemAmount = t.ItemAmount,
                ItemRemark = t.ItemRemark
            }));

            var model = new InvoiceIssueModel
            {
                MerchantID = issue.MerchantID,
                RelateNumber = issue.RelateNumber,
                ClearanceMarkEnum = issue.ClearanceMark,
                CustomerIdentifier = issue.CustomerIdentifier,
                CustomerAddress = issue.CustomerAddress,
                CustomerTel = issue.CustomerTel,
                CustomerEmail = issue.CustomerEmail,
                SalesAmount = issue.SalesAmount,
                TaxAmount = issue.TaxAmount,
                TotalAmount = issue.TotalAmount,
                TaxTypeEnum = issue.TaxType,
                TrackTypeEnum = issue.InvType,
                Items = items,
                SpecialTaxTypeEnum = issue.TaxType == Enum.TaxTypeEnum.SpecTax && issue.InvType == Enum.TrackTypeEnum.Special ? issue.SpecialTaxType : Enum.SpecialTaxTypeEnum.None,
                ZeroTaxRateReasonEnum = issue.ZeroTaxRateReason
            };

            return _service.PostRtnJson<InvoiceIssueModel, InvoiceIssueResult>(model);
        }
    }
}