using System.Collections.Generic;

namespace Shopee.Models.Product.Request
{
    public class ProductRequest
    {
        public decimal original_price { get; set; }
        public string description { get; set; }
        public decimal weight { get; set; }
        public string item_name { get; set; }
        public string item_status { get; set; }
        public Dimension Dimension { get; set; }
        public int normal_stock { get; set; }
        public List<LogisticInfo> logistic_info { get; set; }
        public List<AttributeList> attribute_list { get; set; }
        public int category_id { get; set; }
        public Image image { get; set; }
        public PreOrder pre_order { get; set; }
        public string item_sku { get; set; }
        public string condition { get; set; }
        public Wholesale wholesale { get; set; }
        public string[] video_upload_id { get; set; }
        public Brand Brand { get; set; }
        public int item_dangerous { get; set; }
        public TaxInfo tax_info { get; set; }
        public ComplaintPolicy complaint_policy { get; set; }
    }

    public class Dimension
    {
        public int package_height { get; set; }

        public int package_length { get; set; }
        public int package_width { get; set; }
    }

    public class LogisticInfo 
    {
        public int size_id { get; set; }
        public decimal shipping_fee { get; set; }
        public bool enabled { get; set; }
        public int logistic_id { get; set; }
        public bool is_free { get; set; }
    }

    public class AttributeList 
    {
        public int attribute_id { get; set; }
        public List<AttributeValueList> attribute_value_list { get; set; }

    }

    public class AttributeValueList 
    {
        public int value_id { get; set; }
        public string original_value_name { get; set; }
        public string value_unit { get; set; }
    }

    public class Image
    {
        public string[] image_id_list { get; set; }
    }

    public class PreOrder 
    {
        public bool is_pre_order { get; set; }
        public int days_to_ship { get; set; }
    }

    public class Wholesale
    {
        public int min_count { get; set; }
        public int max_count { get; set; }
        public decimal unit_price { get; set; }
    }

    public class Brand 
    {
        public long brand_id { get; set; }
        public string original_brand_name { get; set; }
    }

    public class TaxInfo
    {
        public string invoice_option { get; set; }
        public string vat_rate { get; set; }
        public string hs_code { get; set; }
        public string tax_code { get; set; }
    }

    public class ComplaintPolicy
    {
        public string warranty_time { get; set; }
        public bool exclude_entrepreneur_warranty { get; set; }
        public bool diff_state_cfop { get; set; }
        public int complaint_address_id { get; set; }
        public string additional_information { get; set; }
    }
}