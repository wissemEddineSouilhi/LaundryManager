namespace LaundryManager.Application.Dtos
{
    public class CreateCommandDto
    {
        public string Reason { get; set; }
        public string Comment { get; set; }
        public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
    }
}
