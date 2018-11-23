namespace Ecpay.EInvoice.Integration.Models
{
    /// <summary>
    /// 查詢折讓作廢回傳Model
    /// </summary>
    public class QueryAllowanceInvalidReturn : ReturnBase
    {
        /// <summary>
        /// 折讓單日期   ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string AI_Allow_Date { get; set; }

        /// <summary>
        /// 折讓單號
        /// </summary>
        public string AI_Allow_No { get; set; }

        /// <summary>
        /// 買方統編    ‧買方統編0000000000代表沒有統編
        /// </summary>
        public string AI_Buyer_Identifier { get; set; }

        /// <summary>
        /// 作廢時間    ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string AI_Date { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string AI_Invoice_No { get; set; }

        /// <summary>
        /// 廠商代號
        /// </summary>
        public string AI_Mer_ID { get; set; }

        /// <summary>
        /// 作廢原因    ‧預設以URL Encode編碼的方式輸出
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 賣方統編
        /// </summary>
        public string AI_Seller_Identifier { get; set; }

        /// <summary>
        /// 上傳時間    ‧預設格式為「yyyy-MM-dd HH:mm:ss」
        /// </summary>
        public string AI_Upload_Date { get; set; }

        /// <summary>
        /// 上傳狀態    ‧固定給定下述預設值 ->若為已上傳時，則VAL = '1'
        ///                                  ->若為未上傳時，則VAL = '0'
        /// </summary>
        public string AI_Upload_Status { get; set; }
    }
}