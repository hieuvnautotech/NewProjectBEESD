namespace NewProjectESDBETL.Models.Dtos.Common
{
    public class ResponseModel<T>
    {
        public int HttpResponseCode { get; set; } = 200;
        public T? Data { get; set; } = default;
        public int? TotalRow { get; set; } = 0;
        public string? ResponseMessage { set; get; } = string.Empty;
    }
}
