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

//發票作廢
namespace IssueInvalid
{
    public partial class IssueInvalid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定發票作廢資訊
            InvoiceInvalid invc = new InvoiceInvalid();
            invc.MerchantID = "2000132";//廠商編號。
            invc.InvoiceNumber = "YE50047080";//發票號碼。
            invc.Reason = "test";//作廢原因。
            //2. 初始化發票Service物件
            Invoice<InvoiceInvalid> inv = new Invoice<InvoiceInvalid>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);
            //6. 解序列化，還原成物件使用
            InvoiceInvalidReturn obj = new InvoiceInvalidReturn();
            obj = JsonConvert.DeserializeObject<InvoiceInvalidReturn>(json);

            string temp = string.Empty;
            //obj.InvoiceNumber
            //obj.RtnCode
            //obj.RtnMsg
            temp = string.Format("作廢結果<br> InvoiceNumber={0} <br> RtnCode={1} <br> RtnMsg={2}", obj.InvoiceNumber, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
        }
    }
}