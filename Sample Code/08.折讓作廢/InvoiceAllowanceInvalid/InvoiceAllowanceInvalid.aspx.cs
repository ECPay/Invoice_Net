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

//折讓作廢
namespace InvoiceAllowanceInvalid
{
    public partial class InvoiceAllowanceInvalid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定開立折讓作廢資訊
            AllowanceInvalid invc = new AllowanceInvalid();
            invc.MerchantID = "2000132";//廠商編號。
            invc.InvoiceNo = "XK00024189";//發票號碼。
            invc.AllowanceNo = "2017121415015512";//折讓單號。
            invc.Reason = "123";//作廢原因。
            //2. 初始化發票Service物件
            Invoice<AllowanceInvalid> inv = new Invoice<AllowanceInvalid>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);
            //6. 解序列化，還原成物件使用
            AllowanceInvalidReturn obj = new AllowanceInvalidReturn();
            obj = JsonConvert.DeserializeObject<AllowanceInvalidReturn>(json);
            //7.列印結果
            string temp = string.Empty;
            //obj.IA_Invoice_No

            temp = string.Format("作廢折讓結果<br> IA_Invoice_No={0}<br> <br> RtnCode={1} <br> RtnMsg={2} ", obj.IA_Invoice_No, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
        }
    }
}