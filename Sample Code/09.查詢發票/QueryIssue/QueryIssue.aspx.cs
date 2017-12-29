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

//查詢發票
namespace QueryIssue
{
    public partial class QueryIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //1. 設定查詢發票資訊
            QueryInvoice qinv = new QueryInvoice();
            qinv.MerchantID = "2000132";//廠商編號。
            qinv.RelateNumber = "ecPay31773";//商家自訂訂單編號。
           

            //2. 初始化發票Service物件
            Invoice<QueryInvoice> inv = new Invoice<QueryInvoice>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qinv);

            //6. 解序列化，還原成物件使用
            QueryInvoiceReturn obj = new QueryInvoiceReturn();
            obj = JsonConvert.DeserializeObject<QueryInvoiceReturn>(json);

            //7.印出結果
            string temp = string.Empty;

            temp = string.Format("查詢發票結果<br>IIS_Relate_Number={0}<br> IIS_Create_Date={1}<br> IIS_Sales_Amount={2}<br> RtnCode={3} <br> RtnCode={4} ", obj.IIS_Relate_Number, obj.IIS_Create_Date, obj.IIS_Sales_Amount, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);


        }
    }
}