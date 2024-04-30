namespace Zonda.Application.Common.Response
{
    public class CustomerOrderMessages
    {
        public static string SuccessfullyCreatedNewOrder => "Product added succesfully to this customer.";
        public static string SuccessfullyDeletedOrder => "Product added succesfully to this customer.";
        public static string FailedToCreatedOrder => "Product deleted succesfully.";
        public static string FailedToDeleteOrder => "Failed to delete.";
    }

    public class CustomResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; } = false;
        public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
