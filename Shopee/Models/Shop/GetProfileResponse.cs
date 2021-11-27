namespace Shopee.Models
{
    public class GetProfileResponse
    {
        public string Message { get; set; }
        public string Request_Id { get; set; }
        public Response Response { get; set; }
        public string Error { get; set; }
    }

    public class Response
    {
        public string Shop_Logo { get; set; }
        public string Description { get; set; }
        public string Shop_Name { get; set; }
    }
}