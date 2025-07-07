using LaundryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Dtos
{
    public class CreateCommandDto
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
    }
}
