namespace Shop.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }
        public CodeErrorException(int StatusCode, string[]? Message = null, string? details = null)
            : base(StatusCode, Message)
        {
            Details = details;
        }
    }
}
