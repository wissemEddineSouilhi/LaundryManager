using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Domain.Entities
{
    public class Command
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public CommandStatus Status { get; set; }
        public Guid StatusId {  get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();   
    }
}
