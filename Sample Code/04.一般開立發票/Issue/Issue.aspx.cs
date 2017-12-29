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

//一般開立發票
namespace Issue
{
    public partial class Issue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定開立發票資訊
            InvoiceCreate invc = new InvoiceCreate();
            invc.MerchantID = "2000132";//廠商編號。
            invc.RelateNumber = "ecPay" + new Random().Next(0, 99999).ToString();//商家自訂訂單編號
            invc.CustomerID = "";//客戶代號
            invc.CustomerIdentifier = "";//統一編號
            invc.CustomerName = "";//客戶名稱
            invc.CustomerAddr = "客戶地址";//客戶地址
            invc.CustomerPhone = "0912345678";//客戶手機號碼
            invc.CustomerEmail = "test@ecpay.com.tw";//客戶電子信箱
            //invc.ClearanceMark = CustomsClearanceMarkEnum.None;//通關方式
            invc.Print = PrintEnum.No;//列印註記
            invc.Donation = DonationEnum.No;//捐贈註記
            invc.LoveCode = "";//愛心碼
            invc.carruerType = CarruerTypeEnum.PhoneBarcode;//載具類別
            invc.CarruerNum = "/6G X3LQ";
            //invc.TaxType = TaxTypeEnum.DutyFree;//課稅類別
            invc.SalesAmount = "300";//發票金額。含稅總金額。
            invc.InvoiceRemark = "(qwrrg)";//備註
            
            invc.invType = TheWordTypeEnum.Normal;//發票字軌類別
            //invc.vat = VatEnum.No;//商品單價是否含稅
            



            //商品資訊(Item)的集合類別。
            invc.Items.Add(new Item()
            {
                ItemName = "糧食",//商品名稱
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemPrice = "100.1",//商品單價
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
                ItemAmount ="100.1",//總金額
                
                
            });
            invc.Items.Add(new Item()
            {
                ItemName = "糧食",//商品名稱
                ItemPrice = "200",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "200",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });
            
            //2. 初始化發票Service物件
            Invoice<InvoiceCreate> inv = new Invoice<InvoiceCreate>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);
            //6. 解序列化，還原成物件使用
            InvoiceCreateReturn obj = new InvoiceCreateReturn();

            obj = JsonConvert.DeserializeObject<InvoiceCreateReturn>(json);
            string temp = string.Empty;
            temp = string.Format("開立發票結果<br> InvoiceDate={0}<br> InvoiceNumber={1}<br> RandomNumber={2}<br> RtnCode={3} <br> RtnCode={4} ", obj.InvoiceDate, obj.InvoiceNumber, obj.RandomNumber, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
        }
    }
}