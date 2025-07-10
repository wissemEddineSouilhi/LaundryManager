using LaundryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Dtos
{
    public class ArticleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ArticleTypeId { get; set; }
    }
}
