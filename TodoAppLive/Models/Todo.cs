using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppLive.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public virtual List<TodoCategory> TodoCategories { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
