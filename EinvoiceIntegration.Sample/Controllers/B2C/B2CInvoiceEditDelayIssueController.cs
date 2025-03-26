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
    public class B2CInvoiceEditDelayIssueController : Controller
    {
        // GET: B2CInvoiceEditDelayIssue
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string EditDelayIssue(InvoiceDelayIssue delayIssue)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.EditDelayIssue,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            var items = new List<EditDelayIssueModel.Item>();
            delayIssue.Items.ForEach(t => items.Add(new EditDelayIssueModel.Item
            {
                ItemName = t.ItemName,
                ItemCount = t.ItemCount,
                ItemWord = t.ItemWord,
                ItemPrice = t.ItemPrice,
                ItemTaxType = t.ItemTaxType.ToString(),
                ItemAmount = t.ItemAmount,
                ItemRemark = t.ItemRemark
            }));

            var model = new EditDelayIssueModel
            {
                MerchantID = delayIssue.MerchantID,
                RelateNumber = delayIssue.RelateNumber,
                ClearanceMarkEnum = delayIssue.ClearanceMark,
                CarrierTypeEnum = delayIssue.CarrierType,
                CarrierNum = delayIssue.CarrierNum,
                PrintEnum = delayIssue.Print,
                DonationEnum = delayIssue.Donation,
                CustomerID = delayIssue.CustomerID,
                CustomerIdentifier = delayIssue.CustomerIdentifier,
                CustomerAddr = delayIssue.CustomerAddr,
                CustomerName = delayIssue.CustomerName,
                CustomerPhone = delayIssue.CustomerPhone,
                CustomerEmail = delayIssue.CustomerEmail,
                SalesAmount = delayIssue.SalesAmount,
                SpecialTaxTypeEnum = delayIssue.TaxType == Enum.TaxTypeEnum.SpecTax && delayIssue.InvType == Enum.TrackTypeEnum.Special ? delayIssue.SpecialTaxType : Enum.SpecialTaxTypeEnum.None,
                ChannelPartnerEnum = delayIssue.ChannelPartner,
                LoveCode = delayIssue.LoveCode,
                VatEnum = delayIssue.Vat,
                TaxTypeEnum = delayIssue.TaxType,
                TrackTypeEnum = delayIssue.InvType,
                Items = items,
                Tsr = delayIssue.Tsr,
                ProductServiceID = delayIssue.ProductServiceID,
            };

            return _service.PostRtnJson<EditDelayIssueModel, EditDelayIssueResult>(model);
        }
    }
}