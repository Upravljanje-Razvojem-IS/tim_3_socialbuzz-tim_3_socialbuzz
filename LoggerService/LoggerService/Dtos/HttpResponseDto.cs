namespace LoggerService.Dtos
{
    public class HttpResponseDto
    {
        public int StatusCode { get; set; }
        public string BodyContent { get; set; }

        public string Outcome { get; set; }
    }
}
