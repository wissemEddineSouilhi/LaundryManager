using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Entities;
using LaundryManager.Infrastructure.Data;

namespace LaundryManager.Infrastructure.Repositories
{
    internal class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(LaundaryDbContext laundaryDbContext) : base(laundaryDbContext)
        {
        }
    }
}
