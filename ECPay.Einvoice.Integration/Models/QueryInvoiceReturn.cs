namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 查詢發票回傳Model
    /// </summary>
    public class QueryInvoiceReturn : ReturnBase
    {
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string IIS_Mer_ID { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string IIS_Number { get; set; }

        /// <summary>
        /// 廠商自訂編號
        /// </summary>
        public string IIS_Relate_Number { get; set; }

        /// <summary>
        /// 客戶編號
        /// </summary>
        public string IIS_Customer_ID { get; set; }

        /// <summary>
        /// 買方統編    ‧買方統編0000000000代表沒有統編
        /// </summary>
        public string IIS_Identifier { get; set; }

        /// <summary>
        /// 客戶名稱    ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string IIS_Customer_Name { get; set; }

        /// <summary>
        /// 客戶地址    ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string IIS_Customer_Addr { get; set; }

        /// <summary>
        /// 客戶電話
        /// </summary>
        public string IIS_Customer_Phone { get; set; }

        /// <summary>
        /// 客戶EMAIL     ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string IIS_Customer_Email { get; set; }

        /// <summary>
        /// 通關方式    ‧固定給定下述預設值 ->若為經海關出口，則VAL = '1'
        ///                                  ->若為非經海關出口，則VAL = '2'
        /// </summary>
        public string IIS_Clearance_Mark { get; set; }

        /// <summary>
        /// 發票種類    ‧固定給定下述預設值 ->若為一般稅額計算時，則VAL = '07'
        ///                                  ->若為特種稅額計算時，則VAL = '08'
        /// </summary>
        public string IIS_Type { get; set; }

        /// <summary>
        /// 發票類別    ‧固定給定下述預設值 ->若為有統編時，則VAL = 'B2B'
        ///                                  ->若為無統編時，則VAL = 'B2C'
        /// </summary>
        public string IIS_Category { get; set; }

        /// <summary>
        /// 課稅別     ‧固定給定下述預設值 ->若為應稅時，則VAL = '1'
        ///                                 ->若為零稅率時，則VAL = '2'
        ///                                 ->若為免稅時，則VAL = '3'
        ///                                 ->若為混合應稅與免稅時，則VAL = '9'
        /// </summary>
        public string IIS_Tax_Type { get; set; }

        /// <summary>
        /// 稅率
        /// </summary>
        public string IIS_Tax_Rate { get; set; }

        /// <summary>
        /// 稅金  ‧當發票為B2B時，才會算出稅金
        ///       ‧當發票為B2C時，稅金包含在發票金額裡，不拆算稅金
        /// </summary>
        public string IIS_Tax_Amount { get; set; }

        /// <summary>
        /// 發票金額
        /// </summary>
        public string IIS_Sales_Amount { get; set; }

        /// <summary>
        /// 發票檢查碼
        /// </summary>
        public string IIS_Check_Number { get; set; }

        /// <summary>
        /// 載具類別    ‧固定給定下述預設值 ->若為無載具時，則VAL = ''
        ///                                  ->若為會員載具時，則VAL = '1'
        ///                                  ->若為買受人之自然人憑證號碼時，則VAL = '2'
        ///                                  ->若為買受人之手機條碼資料時，則VAL = '3'
        /// </summary>
        public string IIS_Carruer_Type { get; set; }

        /// <summary>
        /// 載具編號    ‧若載具類別為無載具或會員載具時，則VAL=''
        ///             ‧若載具類別為買受人之自然人憑證號碼時，則 ->須有值 ->長度固定16碼 ->格式為2碼大小寫字母加上14碼數字
        ///             ‧若載具類別為買受人之手機條碼資料時，則 ->須有值 ->長度固定7碼 ->格式為1碼斜線「/」加上由7碼加號、減號、句號、數字及大小寫字母組成
        /// </summary>
        public string IIS_Carruer_Num { get; set; }

        /// <summary>
        /// 捐款單位愛心碼 財政部 - 查詢社福團體愛心碼https://www.einvoice.nat.gov.tw/APMEMBERVAN/XcaOrgPreserveCodeQuery/XcaOrgPreserveCodeQuery
        /// </summary>
        public string IIS_Love_Code { get; set; }

        /// <summary>
        /// 發票開立IP
        /// </summary>
        public string IIS_IP { get; set; }

        /// <summary>
        /// 發票開立時間  ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string IIS_Create_Date { get; set; }

        /// <summary>
        /// 發票開立狀態  ‧固定給定下述預設值 ->若為發票開立時，則VAL = '1'
        ///                                    ->若為發票註銷時，則VAL = '0'
        /// </summary>
        public string IIS_Issue_Status { get; set; }

        /// <summary>
        /// 發票作廢狀態  ‧固定給定下述預設值 ->若為已作廢時，則VAL = '1'
        ///                                    ->若為未作廢時，則VAL = '0'
        /// </summary>
        public string IIS_Invalid_Status { get; set; }

        /// <summary>
        /// 發票上傳狀態  ‧固定給定下述預設值 ->若為已上傳時，則VAL = '1'
        ///                                    ->若為未上傳時，則VAL = '0'
        /// </summary>
        public string IIS_Upload_Status { get; set; }

        /// <summary>
        /// 發票上傳時間  ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string IIS_Upload_Date { get; set; }

        /// <summary>
        /// 折讓剩餘金額
        /// </summary>
        public string IIS_Remain_Allowance_Amt { get; set; }

        /// <summary>
        /// 列印旗標    ‧固定給定下述預設值 ->若為列印時，則VAL = '1'
        ///                                  ->若為不列印時，則VAL = '0'
        /// </summary>
        public string IIS_Print_Flag { get; set; }

        /// <summary>
        /// 中獎期標    ‧固定給定下述預設值 ->若為未對獎時，則VAL = ''
        ///                                  ->若為未中獎時，則VAL = '0'
        ///                                  ->若為已中獎時，則VAL = '1'
        ///                                  ->若為不可對獎時，則VAL = 'X'，有統編的發票不可對獎
        /// </summary>
        public string IIS_Award_Flag { get; set; }

        /// <summary>
        /// 中獎種類    ‧固定給定下述預設值 ->若為特別獎一千萬時，則VAL = '8'
        ///                                  ->若為特獎二百萬元時，則VAL = '7'
        ///                                  ->若為頭獎二十萬元時，則VAL = '1'
        ///                                  ->若為二獎四萬元時，則VAL = '2'
        ///                                  ->若為三獎一萬元時，則VAL = '3'
        ///                                  ->若為四獎四千元時，則VAL = '4'
        ///                                  ->若為五獎一千元時，則VAL = '5'
        ///                                  ->若為六獎二百元時，則VAL = '6'
        ///                                  ->若為沒中獎時，則VAL = '0'
        /// </summary>
        public string IIS_Award_Type { get; set; }

        /// <summary>
        /// 商品名稱    ‧預設格式如下 名稱1 | 名稱2 | 名稱3 | … | 名稱n
        ///             ‧若含二筆或以上的商品名稱時，則以「|」符號區隔
        ///             ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 商品數量    ‧預設格式如下 數量1 | 數量2 | 數量3 | … | 數量n
        ///             ‧若含二筆或以上的商品數量時，則以「|」符號區隔
        /// </summary>
        public string ItemCount { get; set; }

        /// <summary>
        /// 商品單位    ‧預設格式如下 單位1 | 單位2 | 單位3 | … | 單位n
        ///             ‧若含二筆或以上的商品單位時，則以「|」符號區隔
        ///             ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string ItemWord { get; set; }

        /// <summary>
        /// 商品價格    ‧預設格式如下 價格1 | 價格2 | 價格3 | … | 價格n
        ///             ‧若含二筆或以上的商品價格時，則以「|」符號區隔
        ///             ‧含稅單價金額
        /// </summary>
        public string ItemPrice { get; set; }

        /// <summary>
        /// 商品課稅別   ‧預設格式如下 課稅類別1 |課稅類別2 |課稅類別3 | … |課稅類別n
        ///              ‧若含二筆或以上的商品課稅別時，則以「|」符號區隔
        ///              ‧發票課稅類別需混合應稅與免稅
        ///              ‧商品課稅別固定給定下述預設值 ->若為應稅時，則VAL = '1' ->若為免稅時，則VAL = '3'
        ///              ‧需含二筆或以上的商品課稅別，且至少需有一筆商品課稅別為應稅及至少需有一筆商品課稅別為免稅
        /// </summary>
        public string ItemTaxType { get; set; }

        /// <summary>
        /// 商品合計    ‧預設格式如下合計1 | 合計2 | 合計3 | … | 合計n
        ///             ‧若含二筆或以上的商品合計時，則以「|」符號區隔
        ///             ‧含稅小計金額
        /// </summary>
        public string ItemAmount { get; set; }

        /// <summary>
        /// 發票防偽碼   ‧四碼的隨機數字 (2014-01-01起)
        /// </summary>
        public string IIS_Random_Number { get; set; }

        /// <summary>
        /// 備註  ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string InvoiceRemark { get; set; }
    }
}