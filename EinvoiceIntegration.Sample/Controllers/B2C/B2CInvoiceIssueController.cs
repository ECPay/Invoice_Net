using EinvoiceIntegration.Models.B2C;
using EinvoiceIntegration.Sample.Models.B2C;
using EinvoiceIntegration.Services.B2C;
using EinvoiceIntegration.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EinvoiceIntegration.Sample.Controllers
{
    public class B2CInvoiceIssueController : Controller
    {
        // GET: B2CInvoice
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string InvoiceIssue(InvoiceIssue issue)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.Issue,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            var items = new List<InvoiceIssueModel.Item>();
            issue.Items.ForEach(t => items.Add(new InvoiceIssueModel.Item
            {
                ItemName = t.ItemName,
                ItemCount = t.ItemCount,
                ItemWord = t.ItemWord,
                ItemPrice = t.ItemPrice,
                ItemTaxType = t.ItemTaxType.ToString(),
                ItemAmount = t.ItemAmount,
                ItemRemark = t.ItemRemark
            }));

            var model = new InvoiceIssueModel
            {
                MerchantID = issue.MerchantID,
                RelateNumber = issue.RelateNumber,
                ClearanceMarkEnum = issue.ClearanceMark,
                CarrierTypeEnum = issue.CarrierType,
                CarrierNum = issue.CarrierNum,
                PrintEnum = issue.Print,
                DonationEnum = issue.Donation,
                CustomerID = issue.CustomerID,
                CustomerIdentifier = issue.CustomerIdentifier,
                CustomerAddr = issue.CustomerAddr,
                CustomerName = issue.CustomerName,
                CustomerPhone = issue.CustomerPhone,
                CustomerEmail = issue.CustomerEmail,
                SalesAmount = issue.SalesAmount,
                SpecialTaxTypeEnum = issue.TaxType == Enum.TaxTypeEnum.SpecTax && issue.InvType == Enum.TrackTypeEnum.Special ? issue.SpecialTaxType : Enum.SpecialTaxTypeEnum.None,
                ChannelPartnerEnum = issue.ChannelPartner,
                LoveCode = issue.LoveCode,
                VatEnum = issue.Vat,
                TaxTypeEnum = issue.TaxType,
                TrackTypeEnum = issue.InvType,
                Items = items,
                ProductServiceID = issue.ProductServiceID,
                ZeroTaxRateReasonEnum = issue.ZeroTaxRateReason
            };

            return _service.PostRtnJson<InvoiceIssueModel, InvoiceIssueResult>(model);
        }
    }
}