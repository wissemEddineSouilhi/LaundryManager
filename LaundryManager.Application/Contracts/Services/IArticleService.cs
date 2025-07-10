using LaundryManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Contracts.Services
{
    public interface IArticleService
    {
        Task<IList<ArticleTypeDto>> GetArticleTypesAsync();
    }
}
