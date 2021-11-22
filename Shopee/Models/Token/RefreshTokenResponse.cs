namespace Shopee.Models
{
    public class RefreshTokenResponse
    {
        public string Request_Id { get; set; }
        public string Error { get; set; }
        public string Refresh_Token { get; set; }
        public string Access_Token { get; set; }
        public int Expire_In { get; set; }
        public int Partner_Id { get; set; }
        public int Shop_Id { get; set; }
        public int Merchant_Id { get; set; }
    }
}