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

//查詢折讓明細
namespace InvoiceQueryAllowance
{
    public partial class InvoiceQueryAllowance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定開立折讓資訊
            QueryAllowance qa = new QueryAllowance();
            qa.MerchantID = "2000132";//廠商編號。
            qa.InvoiceNo = "XK00024189";//發票號碼。
            qa.AllowanceNo = "2017121415015512";//折讓編號。

            /***折讓單號忘記了請到後台按列印確認***/

            //2. 初始化發票Service物件
            Invoice<QueryAllowance> inv = new Invoice<QueryAllowance>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qa);
            //6. 解序列化，還原成物件使用
            QueryAllowanceReturn obj = new QueryAllowanceReturn();
            obj = JsonConvert.DeserializeObject<QueryAllowanceReturn>(json);

            //7.印出結果
            string temp = string.Empty;
            //obj.IA_Allow_No
            //obj.IA_Invoice_No
            //obj.RtnCode
            //obj.RtnMsg

            temp = string.Format("查詢折讓發票<br> IA_Invoice_No={0} <br> RtnCode={1} <br> RtnMsg={2}", obj.IA_Invoice_No, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
        }
    }
}