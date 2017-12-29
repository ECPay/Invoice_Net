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

//開立折讓
namespace InvoiceAllowance
{
    public partial class InvoiceAllowance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. 設定開立折讓資訊
            Allowance invc = new Allowance();
            invc.MerchantID = "2000132";//廠商編號。
            invc.InvoiceNo = "XW00006065";//發票號碼。
            invc.allowanceNotify = AllowanceNotifyEnum.SMS;//通知類別
            invc.CustomerName = "客戶名稱";//客戶名稱
            invc.NotifyPhone = "0912345678";//客戶手機號碼
            invc.NotifyMail = "";//客戶電子信箱
            invc.AllowanceAmount = "10";//折讓單總金額(含稅總金額)。
            //商品資訊的集合類別
            invc.Items.Add(new Item()
            {
                ItemName = "糧食",//商品名稱
                ItemPrice = "10",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "10",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });
            //2. 初始化發票Service物件
            Invoice<Allowance> inv = new Invoice<Allowance>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);
            //6. 解序列化，還原成物件使用
            AllowanceReturn obj = new AllowanceReturn();
            obj = JsonConvert.DeserializeObject<AllowanceReturn>(json);
            //**印出來**

            string temp = string.Empty;
            temp = string.Format("折讓結果<br> IA_Allow_No={0}<br> IA_Date={1}<br> IA_Invoice_No={2}<br> RtnCode={3} <br> RtnMsg={4} <br>IA_Remain_Allowance_Amt ={5} ", obj.IA_Allow_No, obj.IA_Date, obj.IA_Invoice_No, obj.RtnCode, obj.RtnMsg, obj.IA_Remain_Allowance_Amt);
            Response.Write(temp);
        }
    }
}