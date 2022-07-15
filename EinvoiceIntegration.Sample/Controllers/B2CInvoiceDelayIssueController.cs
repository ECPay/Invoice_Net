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
            //範例View
            return View();
        }

        [HttpPost]
        public string DelayIssue(InvoiceDelayIssue delayIssue)
        {
            //1. 設定延遲開立發票資訊(此範例由View傳入model所需資訊)

            //2. 初始化發票Service物件
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,           //指定測試環境, 上線時請記得改為Prod
                B2CEnum = Enum.B2C.B2CInvoiceMethod.DelayIssue, //指定呼叫的API
                HashKey = "ejCk326UnaZWKisg",                   //設定綠界提供的Key
                HashIV = "q9jcZX8Ib9LM8wYk"                     //設定綠界提供的IV
            };

            //3. 轉換為SDK提供的model
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
                LoveCode = delayIssue.LoveCode,
                VatEnum = delayIssue.Vat,
                TaxTypeEnum = delayIssue.TaxType,
                TrackTypeEnum = delayIssue.InvType,
                Items = items,
                DelayDay = delayIssue.DelayDay,
                Tsr = delayIssue.Tsr,
                PayType = "2",
                PayAct = "ECPAY"
            };

            //4. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            return _service.PostRtnJson<DelayIssueModel, DelayIssueResult>(model);
        }
    }
}