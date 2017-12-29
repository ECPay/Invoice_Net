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

//查詢作廢發票
namespace QueryIssueInvalid
{
    public partial class QueryIssueInvalid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定發票作廢資訊
            QueryInvoiceInvalid qini = new QueryInvoiceInvalid();
            qini.MerchantID = "2000132";//廠商編號。
            qini.RelateNumber = "bffb2f1952564c32973c139b8b1925";//商家自訂訂單編號。
            //2. 初始化發票Service物件
            Invoice<QueryInvoiceInvalid> inv = new Invoice<QueryInvoiceInvalid>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qini);
            //6. 解序列化，還原成物件使用
            QueryInvoiceInvalidReturn obj = new QueryInvoiceInvalidReturn();
            obj = JsonConvert.DeserializeObject<QueryInvoiceInvalidReturn>(json);
            string temp = string.Empty;
            //obj.II_Invoice_No
            // obj.Reason
            // obj.RtnMsg
            temp = string.Format("查詢作廢發票<br> II_Invoice_No={0} <br> Reason={1} <br> RtnMsg={2}", obj.II_Invoice_No, obj.Reason, obj.RtnMsg);
            Response.Write(temp);
        }
    }
}