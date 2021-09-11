namespace LoggerService.Dtos
{
    public class HttpRequestDto
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string BodyContent { get; set; }
    }
}
