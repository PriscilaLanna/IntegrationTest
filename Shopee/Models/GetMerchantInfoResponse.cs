namespace Shopee.Models
{
    public class GetMerchantInfoResponse
    {
        public string Merchant_Name { get; set; }
        public bool Is_Cnsc { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public long Expire_Time { get; set; }
        public string Request_Id { get; set; }
    }
}