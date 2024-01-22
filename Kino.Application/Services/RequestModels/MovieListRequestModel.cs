namespace Kino.Presentation.WebApi.RequestModels
{
    public class MovieListRequestModel
    {
        public string? SearchString { get; set; }
        public int? PageSize { get; set; } = 50;
        public int? PageIndex { get; set; } = 0;
    }
}
