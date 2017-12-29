using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecpay.EInvoice.Integration.Models;
using Ecpay.EInvoice.Integration.Service;
using Ecpay.EInvoice.Integration.Enumeration;
using Newtonsoft.Json;

//延遲或觸發開立發票
namespace DelayIssue
{
    public partial class DelayIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //1. 設定觸發或延遲開立發票資訊
            InvoiceDelay invc = new InvoiceDelay();
            invc.MerchantID = "2000132";//廠商編號
            invc.DelayFlag = DelayFlagEnum.NormalDelay;//延遲註記
            invc.RelateNumber = "ecPaytest" + new Random().Next(0, 99999).ToString();//商家自訂訂單編號
            invc.CustomerID = "ttee11";//客戶代號
            invc.CustomerIdentifier = "";//統一編號            
            invc.CustomerName = "";//客戶名稱
            invc.CustomerAddr = "";//客戶地址
            invc.CustomerPhone = "0912345678";//客戶手機號碼
            invc.CustomerEmail = "test@allpay.com.tw";//客戶電子信箱
            //invc.ClearanceMark = CustomsClearanceMarkEnum.None;//通關方式
            invc.Print = PrintEnum.No;//列印註記
            invc.Donation = DonationEnum.No;//捐贈註記
            //invc.LoveCode = "930";//愛心碼
            invc.carruerType = CarruerTypeEnum.PhoneBarcode;//載具類別
            invc.CarruerNum = "/6G X3LQ";//載具編號
            invc.TaxType = TaxTypeEnum.DutyFree;//課稅類別
            invc.SalesAmount = "200";//發票金額。含稅總金額
            invc.InvoiceRemark = "";//備註
            invc.DelayDay = "0";//延遲天數
            //invc.ECBankID = "";//ECBank 代號          
            invc.Tsr = "ecPaytest" + new Random().Next(0, 99999).ToString();//交易單號
            invc.PayType = PayTypeEnum.ECPAY;//交易類別
            //invc.NotifyURL = "";//開立完成時通知廠商的網址
            //invc.invType = TheWordTypeEnum.Normal;//發票字軌類別
            //invc.vat = VatEnum.No;//商品單價是否含稅

            //商品資訊(Item)的集合類別。
            invc.Items.Add(new Item()
            {
                ItemName = "1111111",//商品名稱
                ItemPrice = "100",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "100",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });
            invc.Items.Add(new Item()
            {
                ItemName = "1111111",//商品名稱
                ItemPrice = "100",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "100",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });

            //2. 初始化發票Service物件
            Invoice<InvoiceDelay> inv = new Invoice<InvoiceDelay>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);

            //6. 解序列化，還原成物件使用
            InvoiceDelayReturn obj = new InvoiceDelayReturn();
            obj = JsonConvert.DeserializeObject<InvoiceDelayReturn>(json);

            /*資料顯示*/
            string Result = string.Empty;

            Result = string.Format("延遲觸發開立發票結果:<br> OrderNumber = {0} <br> RtnCode={1} <br> RtnMsg={2}", obj.OrderNumber, obj.RtnCode, obj.RtnMsg);
            Response.Write(Result);




        }
    }
}