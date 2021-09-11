namespace LoggerService.Model
{
    public enum Outcome
    {
        SUCCESS, ERROR
    }
    public class HttpResponse
    {
        public int StatusCode { get; set; }
        public string BodyContent { get; set; }

        public Outcome Outcome { get; set; }
    }
}
