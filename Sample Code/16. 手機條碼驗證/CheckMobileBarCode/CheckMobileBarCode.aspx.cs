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

namespace CheckMobileBarCode
{
    public partial class CheckMobileBarCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MobileBarcode qinv = new MobileBarcode();

            qinv.MerchantID = "2000132";//廠商編號。
            qinv.BarCode = "/6G X3LQ";

            Invoice<MobileBarcode> inv = new Invoice<MobileBarcode>();

            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            
            string json = inv.post(qinv);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

          
            string temp = string.Empty;
            temp = string.Format("結果<br> Data={0} ", values["IsExist"].ToString());
            Response.Write(temp);
            temp = string.Format("結果<br> RtnCode={0} ", values["RtnCode"].ToString());
            Response.Write(temp);

        }
    }
}