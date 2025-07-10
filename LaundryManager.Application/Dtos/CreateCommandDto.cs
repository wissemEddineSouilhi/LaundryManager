namespace LaundryManager.Application.Dtos
{
    public class CreateCommandDto
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
        public List<ArticleDto> Articles { get; set; }
    }
}
