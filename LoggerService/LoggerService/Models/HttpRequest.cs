namespace LoggerService.Model
{
    public enum HttpMethod
    {
        GET, POST, PUT, DELETE, HEAD
    }
    public class HttpRequest
    {
        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public string BodyContent { get; set; }
    }
}
