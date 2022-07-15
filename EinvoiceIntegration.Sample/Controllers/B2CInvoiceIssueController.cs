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
            //範例View
            return View();
        }

        [HttpPost]
        public string InvoiceIssue(InvoiceIssue issue)
        {
            //1. 設定開立發票資訊(此範例由View傳入model所需資訊)

            //2. 初始化發票Service物件
            var _service = new B2CInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,       //指定測試環境, 上線時請記得改為Prod
                B2CEnum = Enum.B2C.B2CInvoiceMethod.Issue,  //指定呼叫的API
                HashKey = "ejCk326UnaZWKisg",               //設定綠界提供的Key
                HashIV = "q9jcZX8Ib9LM8wYk"                 //設定綠界提供的IV
            };

            //3. 轉換為SDK提供的model
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
                LoveCode = issue.LoveCode,
                VatEnum = issue.Vat,
                TaxTypeEnum = issue.TaxType,
                TrackTypeEnum = issue.InvType,
                Items = items
            };

            //4. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            return _service.PostRtnJson<InvoiceIssueModel, InvoiceIssueResult>(model);
        }
    }
}