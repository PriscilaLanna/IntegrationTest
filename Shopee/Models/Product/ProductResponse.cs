namespace Shopee.Models.Product.Response
{
    public class ProductResponse
    {
        public string message { get; set; }
        public string warning { get; set; }
        public string request_id { get; set; }
        public Response Response { get; set; }
    }

    public class Response
    {
        public string description { get; set; }
        public int weight { get; set; }
        public PreOrder pre_order { get; set; }
        public string item_name { get; set; }
        public Images Images { get; set; }
        public string item_status { get; set; }
        public PriceInfo price_info { get; set; }
        public LogisticInfo logistic_info { get; set; }

    }

    public class PreOrder
    {
        public int days_to_ship { get; set; }
        public bool is_pre_order { get; set; }
    }

    public class Images
    {
        public string[] image_id_list { get; set; }
        public string[] image_url_list { get; set; }
    }

    public class PriceInfo
    {
        public decimal current_price { get; set; }
        public decimal original_price { get; set; }
    }

    public class LogisticInfo
    {
        public int size_id { get; set; }
        public decimal shipping_fee { get; set; }
        public bool enabled { get; set; }
        public int logistic_id { get; set; }
        public bool is_free { get; set; }
    }
}