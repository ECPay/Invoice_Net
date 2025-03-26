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
    public class B2CInvoiceDelayIssueController : Controller
    {
        // GET: B2CInvoiceDelayIssue
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string DelayIssue(InvoiceDelayIssue delayIssue)
        {
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,
                B2CEnum = Enum.B2C.B2CInvoiceMethod.DelayIssue,
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk"
            };

            var items = new List<DelayIssueModel.Item>();
            delayIssue.Items.ForEach(t => items.Add(new DelayIssueModel.Item
            {
                ItemName = t.ItemName,
                ItemCount = t.ItemCount,
                ItemWord = t.ItemWord,
                ItemPrice = t.ItemPrice,
                ItemTaxType = t.ItemTaxType.ToString(),
                ItemAmount = t.ItemAmount,
                ItemRemark = t.ItemRemark
            }));

            var model = new DelayIssueModel
            {
                MerchantID = delayIssue.MerchantID,
                DelayFlagEnum = delayIssue.DelayFlag,
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
                DelayDay = delayIssue.DelayDay,
                Tsr = delayIssue.Tsr,
                PayType = "2",
                PayAct = "ECPAY",
                ProductServiceID = delayIssue.ProductServiceID,
                ZeroTaxRateReasonEnum = delayIssue.ZeroTaxRateReason
            };

            return _service.PostRtnJson<DelayIssueModel, DelayIssueResult>(model);
        }
    }
}