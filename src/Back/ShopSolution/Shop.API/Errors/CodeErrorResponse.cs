using System.Text.Json;

namespace Shop.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; init; }
        public string[]? Message { get; set; }

        public CodeErrorResponse(int StatusCode, string[]? Message)
        {
            this.StatusCode = StatusCode;

            if (Message is null)
            {
                _ = new string[] { GetDefaultMessageForStatusCode(StatusCode) };
            }
            else
            {
                this.Message = Message;
            }
        }

        private static string GetDefaultMessageForStatusCode(int StatusCode)
        {
            return StatusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Internal Server Error",
                _ => string.Empty,
            };
        }
    }
}
