namespace LaundryManager.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public ArticleType ArticleType { get; set; }
        public Guid ArticleTypeId { get; set; }
        public Command Command { get; set; }
        public Guid CommandId { get; set; }
    }
}
