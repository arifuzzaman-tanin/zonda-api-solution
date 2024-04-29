namespace Zonda.Application.Common.Response
{
    public class CustomerOrderMessages
    {
        public static string SuccessfullyCreatedNewOrder => "Product added succesfully to this customer.";
        public static string FailedToCreatedNewOrder => "Failed to add new product to this customer.";
    }

    public class CustomResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; } = false;
        public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
