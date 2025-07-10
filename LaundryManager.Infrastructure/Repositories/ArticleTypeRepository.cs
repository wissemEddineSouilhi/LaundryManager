using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Entities;
using LaundryManager.Infrastructure.Data;

namespace LaundryManager.Infrastructure.Repositories
{
    internal class ArticleTypeRepository : RepositoryBase<ArticleType>, IArticleTypeRepository
    {
        public ArticleTypeRepository(LaundaryDbContext laundaryDbContext) : base(laundaryDbContext)
        {
        }
    }
}
