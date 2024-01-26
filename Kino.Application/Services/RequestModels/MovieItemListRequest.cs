namespace Kino.Application.Services.RequestModels
{
    public class MovieItemListRequest
    {
        public string? SearchString { get; set; }
        public int? PageSize { get; set; } = 50;
        public int? PageIndex { get; set; } = 0;
    }
}