namespace E;

public class ApiException : ApiResponse
{
    public ApiException(int statusCode, string message = null, string details = null) :
        base(statusCode, message)
    {
        Detalis = details;
    }

    public string Detalis { get; set; }
}
