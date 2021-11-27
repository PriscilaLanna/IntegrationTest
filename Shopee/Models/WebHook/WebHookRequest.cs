using System.Collections.Generic;

namespace Shopee.Models.WebHook
{
    public class WebHookRequest
    {
        public int Code { get; set; }
        public int Shop_Iid { get; set; }
        public long TimeStamp { get; set; }
        public Data Data { get; set; }
        public bool Success { get; set; }
        public string Extra { get; set; }

    }

    public class Data
    {
        public List<Items> Items { get; set; }
        public string OrderSn { get; set; }
        public string Status { get; set; }
        public long Update_Time { get; set; }
        public string TrackingNo { get; set; }
    }

    public class Items
    {

    }
}