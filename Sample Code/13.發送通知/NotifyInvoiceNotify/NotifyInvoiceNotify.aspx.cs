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

//發送通知
namespace NotifyInvoiceNotify
{
    public partial class NotifyInvoiceNotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定發送通知資訊
            InvoiceNotify invn = new InvoiceNotify();
            invn.MerchantID = "2000132";//廠商編號。
            invn.InvoiceNo = "XK00023301";//發票號碼。
            //invn.AllowanceNo = "2016010615502774";//折讓編號。
            invn.Phone = "0912345678";//發送簡訊號碼。
            invn.NotifyMail = "vicky.lan@ecpay.com.tw";//發送電子信箱。
            invn.notify = InvoiceNotifyEnum.Email;//發送方式。
            invn.invoiceTag = InvoiceTagEnum.Create;//發送內容類型。 
            invn.notified = NotifiedObjectEnum.All;//發送對象。
            //2. 初始化發票Service物件
            Invoice<InvoiceNotify> inv = new Invoice<InvoiceNotify>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invn);
            //6. 解序列化，還原成物件使用
            InvoiceNotifyReturn obj = new InvoiceNotifyReturn();
            obj = JsonConvert.DeserializeObject<InvoiceNotifyReturn>(json);
            //7.印出結果
            string temp = string.Empty;

            //obj.MerchantID

            temp = string.Format("發送結果<br> MerchantID={0} <br> RtnCode={1} <br> RtnMsg={2}", obj.MerchantID, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
        }
    }
}