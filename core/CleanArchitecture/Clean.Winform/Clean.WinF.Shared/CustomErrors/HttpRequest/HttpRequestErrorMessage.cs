
namespace Clean.WinF.Shared.ErrorMessage.HttpRequest
{
    public static class HttpRequestErrorMessage
    {
        public const string HttpRequestErr400 = "400 - The request cannot be fulfilled due to bad syntax.";

        public const string HttpRequestErr401 = "401 - The request was a legal request, but the server is refusing to respond to it. For use when authentication is possible but has failed or not yet been provided.";

        public const string HttpRequestErr403 = "403 - The request was a legal request, but the server is refusing to respond to it.";

        public const string HttpRequestErr404 = "404 - The requested page could not be found but may be available again in the future.";

        public const string HttpRequestErr405 = "405 - A request was made of a page using a request method not supported by that page.";

        public const string HttpRequestErr406 = "406 -The server can only generate a response that is not accepted by the client.";

        public const string HttpRequestErr408 = "408 - The server timed out waiting for the request.";

        public const string HttpRequestErr409 = "409 - The request could not be completed because of a conflict in the request.";

        public const string HttpRequestErr413 = "413 - The server will not accept the request, because the request entity is too large.";

        public const string HttpRequestErr417 = "417 - The server cannot meet the requirements of the Expect request-header field.";


        public const string HttpRequestErr500 = "500 - Internal server error. Please go to the log file to check more detail.";

        public const string HttpRequestErr501 = "501 - Not Implemented. The server either does not recognize the request method.";

        public const string HttpRequestErr502 = "502 - Bad Gateway. The server was acting as a gateway or proxy and received an invalid response from the upstream server.";

        public const string HttpRequestErr503 = "503 - Service Unavailable. The server cannot handle the request (because it is overloaded or down for maintenance).";

        public const string HttpRequestErr504 = "504 - Gateway Timeout. The server was acting as a gateway or proxy and did not receive a timely response from the upstream server.";

        public const string HttpRequestErr505 = "505 - The server does not support the HTTP protocol version used in the request.";

        public const string HttpRequestErr511 = "511 - The client needs to authenticate to gain network access.";


    }
}
