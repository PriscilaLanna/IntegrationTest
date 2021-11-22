namespace Shopee.Models
{
    public class AccessTokenResponse
    {
        public string Request_Id { get; set; }
        public string Error { get; set; }
        public string Refresh_Token { get; set; }
        public string Access_Token { get; set; }
        public int Expire_In { get; set; }
        public string Message { get; set; }
        public int[] Merchant_Id_List { get; set; }
        public int[] Shop_Id_List { get; set; }
    }
}