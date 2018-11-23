namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 查詢折讓回傳Model
    /// </summary>
    public class QueryAllowanceReturn : ReturnBase
    {
        /// <summary>
        /// 折讓單號
        /// </summary>
        public string IA_Allow_No { get; set; }

        /// <summary>
        /// 折讓通知    ‧固定給定下述預設值 ->若為簡訊時，則VAL = 'S'
        ///                                  ->若為電子郵件時，則VAL = 'E'
        ///                                  ->若為皆通知時，則VAL = 'A'
        ///                                  ->若為皆不通知時，則VAL = 'N'
        /// </summary>
        public string IA_Check_Send_Mail { get; set; }

        /// <summary>
        /// 折讓時間    ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string IA_Date { get; set; }

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
        /// 商品營業稅額  ‧預設格式如下 稅額1 | 稅額2 | 稅額3 | … | 稅額n
        ///               ‧若含二筆或以上的商品營業稅額時，則以「|」符號區隔
        /// </summary>
        public string ItemRateAmt { get; set; }

        /// <summary>
        /// 商品課稅別   ‧預設格式如下 課稅類別1 |課稅類別2 |課稅類別3 | … |課稅類別n
        ///              ‧若含二筆或以上的商品課稅別時，則以「|」符號區隔
        ///              ‧發票課稅類別需混合應稅與免稅
        ///              ‧商品課稅別固定給定下述預設值 ->若為應稅時，則VAL = '1' ->若為免稅時，則VAL = '3'
        ///              ‧需含二筆或以上的商品課稅別，且至少需有一筆商品課稅別為應稅及至少需有一筆商品課稅別為免稅
        /// </summary>
        public string ItemTaxType { get; set; }

        /// <summary>
        /// 商品合計    ‧預設格式如下 合計1 | 合計2 | 合計3 | … | 合計n
        ///             ‧若含二筆或以上的商品合計時，則以「|」符號區隔
        ///             ‧含稅小計金額
        /// </summary>
        public string ItemAmount { get; set; }

        /// <summary>
        /// 折讓IP
        /// </summary>
        public string IA_IP { get; set; }

        /// <summary>
        /// 買受人統編   ‧買方統編0000000000代表沒有統編
        /// </summary>
        public string IA_Identifier { get; set; }

        /// <summary>
        /// 折讓作廢狀態  ‧補充說明 ->若折讓單已作廢時，則VAL='1'
        ///                          ->若折讓單未作廢時，則VAL='0'
        /// </summary>
        public string IA_Invalid_Status { get; set; }

        /// <summary>
        /// 發票開立時間  ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string IA_Invoice_Issue_Date { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string IA_Invoice_No { get; set; }

        /// <summary>
        /// 廠商代號
        /// </summary>
        public string IA_Mer_ID { get; set; }

        /// <summary>
        /// 通知的MAIL ‧送出通知時，所送到Email
        /// </summary>
        public string IA_Send_Mail { get; set; }

        /// <summary>
        /// 通知的手機   ‧送出通知時，所送的手機號碼
        /// </summary>
        public string IA_Send_Phone { get; set; }

        /// <summary>
        /// 營業稅額合計
        /// </summary>
        public string IA_Tax_Amount { get; set; }

        /// <summary>
        /// 課稅別     ‧固定給定下述預設值 ->若為應稅時，則VAL = '1'
        ///                                 ->若為零稅率時，則VAL = '2'
        ///                                 ->若為免稅時，則VAL = '3'
        /// </summary>
        public string IA_Tax_Type { get; set; }

        /// <summary>
        /// 金額合計(不含稅之進貨額)
        /// </summary>
        public string IA_Total_Amount { get; set; }

        /// <summary>
        /// 金額合計(含稅)
        /// </summary>
        public string IA_Total_Tax_Amount { get; set; }

        /// <summary>
        /// 上傳時間    ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string IA_Upload_Date { get; set; }

        /// <summary>
        /// 折讓上傳狀態  ‧固定給定下述預設值 ->若為已上傳時，則VAL = '1'
        ///                                    ->若為未上傳時，則VAL = '0'
        /// </summary>
        public string IA_Upload_Status { get; set; }

        /// <summary>
        /// 買受人姓名
        /// </summary>
        public string IIS_Customer_Name { get; set; }
    }
}