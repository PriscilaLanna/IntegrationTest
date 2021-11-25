using System.Collections.Generic;

namespace Shopee.Models.Order
{
    public class GetOrderResponse
    {
        public string Message { get; set; }
        public string Request_Id { get; set; }
        public Response Response { get; set; }
        public string Error { get; set; }
    }

    public class Response
    {
        public bool More { get; set; }
        public string Next_Cursor { get; set; }
        public List<OrderList> Order_List { get; set; }
    }

    public class OrderList
    {
        public string Order_Sn { get; set; }
        public string Order_Status { get; set; }
    }
}