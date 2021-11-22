namespace Shopee.Models
{
    public class GetShopInfoResponse
    {
        public string Shop_Name { get; set; }
        public string Region { get; set; }
        public string Status { get; set; }
        public Sip_Affi_Shops[] Sip_Affi_Shops { get; set; }
        public bool Is_Cb { get; set; }
        public bool Is_Cnsc { get; set; }
        public string Request_Id { get; set; }
        public long Auth_Time { get; set; }
        public long Expire_Time { get; set; }
    }

    public class Sip_Affi_Shops
    {
        public string Affi_Shop_Id { get; set; }
        public string Region { get; set; }
    }
}