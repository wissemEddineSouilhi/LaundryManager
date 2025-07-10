using LaundryManager.Application.Contracts.Services;
using LaundryManager.Application.Dtos;
using LaundryManager.Domain.Contracts.Repositories;
using LaundryManager.Domain.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Services
{
    internal class ArticleService : IArticleService
    {
        IArticleTypeRepository _ArticleTypeRepository;

        public ArticleService(IArticleTypeRepository articleTypeRepository)
        {

            _ArticleTypeRepository = articleTypeRepository;
        }

        public async Task<IList<ArticleTypeDto>> GetArticleTypesAsync()
        {
            var articleTypes = await _ArticleTypeRepository.GetAllAsync();
            var articleTypesDtos = articleTypes.Select(x => new ArticleTypeDto()
                                   {
                                        Id = x.Id,
                                        Name = x.Name,
                                   }).ToList();

            return articleTypesDtos;
        }
    }
}
