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
            //範例View
            return View();
        }

        [HttpPost]
        public string InvoiceIssue(InvoiceIssue issue)
        {
            //1. 設定開立發票資訊(此範例由View傳入model所需資訊)

            //2. 初始化發票Service物件
            var _service = new B2BInvoiceService
            {
                EnvEnum = Enum.EnvironmentEnum.Stage,       //指定測試環境, 上線時請記得改為Prod
                B2BEnum = Enum.B2B.B2BInvoiceMethod.Issue,  //指定呼叫的API
                HashKey = "ejCk326UnaZWKisg",               //設定綠界提供的Key
                HashIV = "q9jcZX8Ib9LM8wYk"                 //設定綠界提供的IV
            };

            //3. 轉換為SDK提供的model
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
                Items = items
            };

            //4. 執行API的回傳結果(JSON)字串
            //此範例直接將結果顯示至View畫面，也可改用service.Post()回傳結果物件
            return _service.PostRtnJson<InvoiceIssueModel, InvoiceIssueResult>(model);
        }
    }
}