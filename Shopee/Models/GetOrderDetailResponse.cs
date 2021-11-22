namespace Shopee.Models.OrderDetail
{
    public class GetOrderDetailResponse
    {
        public string Message { get; set; }
        public string Request_Id { get; set; }
        public Response Response { get; set; }
        public string Error { get; set; }
        public string[] Warning { get; set; }
    }

    public class Response
    {
        public OrderList Order_List { get; set; }
    }

    public class OrderList
    {
        public string Checkout_Shipping_Carrier { get; set; }
        public decimal Reverse_Shipping_Fee { get; set; }
        public decimal Actual_Shipping_Fee { get; set; }
        public bool Actual_Shipping_Fee_Confirmed { get; set; }
        public string Buyer_Cancel_Reason { get; set; }
        public int Buyer_Cpf_Id { get; set; }
        public int Buyer_User_Id { get; set; }
        public string Buyer_Username { get; set; }
        public int Cancel_By { get; set; }
        public string Cancel_Reason { get; set; }
        public bool Cod { get; set; }
        public int Create_Time { get; set; }
        public string Credit_Card_Number { get; set; }
        public string Currency { get; set; }
        public int Days_To_Ship { get; set; }
        public string Dropshipper { get; set; }
        public string Dropshipper_Phone { get; set; }
        public decimal Estimated_Shipping_Fee { get; set; }
        public string Fulfillment_Flag { get; set; }
        public string Goods_To_Declare { get; set; }
        public InvoiceData Invoice_Data { get; set; }
        public ItemList Item_List { get; set; }
        public string Message_To_Seller { get; set; }
        public string Note { get; set; }
        public string Note_Update_Time { get; set; }
        public string Order_Sn { get; set; }
        public string Order_Status { get; set; }
        public PackageList Package_List { get; set; }
        public int Pay_Time { get; set; }
        public string Payment_Method { get; set; }
        public int Pickup_Done_Time { get; set; }
        public RecipientAddress Recipient_Address { get; set; }
        public string Region { get; set; }
        public int Ship_By_Date { get; set; }
        public string Shipping_Carrier { get; set; }
        public bool Split_Up { get; set; }
        public decimal Total_Amount { get; set; }
        public int Update_Time { get; set; }
    }

    public class InvoiceData 
    {
        public string Number { get; set; }
        public string Series_Number { get; set; }
        public string Access_Key { get; set; }
        public int Issue_Date { get; set; }
        public decimal Total_Value { get; set; }
        public decimal Products_Total_Value { get; set; }
        public string Tax_Code { get; set; }
    }

    public class ItemList
    {
        public int Item_Id { get; set; }
        public string Item_Name { get; set; }
        public string Item_Sku { get; set; }
        public int Model_Id { get; set; }
        public string Model_Name { get; set; }
        public string Model_Sku { get; set; }
        public int Model_Quantity_Purchased { get; set; }
        public decimal Model_Original_Price { get; set; }
        public decimal Model_Discounted_Price { get; set; }
        public bool Wholesale { get; set; }
        public decimal Weight { get; set; }
        public bool Add_On_Deal { get; set; }
        public bool Main_Item { get; set; }
        public int Add_On_Deal_Id { get; set; }
        public string Promotion_Type { get; set; }
        public int Promotion_Id { get; set; }
        public int Order_Item_Id { get; set; }
        public int Promotion_Group_Id { get; set; }
        public ImageInfo Image_Info { get; set; }
    }

    public class ImageInfo
    {
        public string Image_Url { get; set; }
    }

    public class PackageList 
    {
        public string Package_Number { get; set; }
        public string Logistics_Status { get; set; }
        public string Shipping_Carrier { get; set; }
        public PackageItemList Item_List { get; set; }
    }

    public class PackageItemList
    {
        public int Item_Id { get; set; }
        public int Model_Id { get; set; }
    }

    public class RecipientAddress
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string  City { get; set; }
        public string  State { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string Full_Address { get; set; }
    }
}