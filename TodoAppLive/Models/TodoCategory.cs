using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppLive.Models
{
    public class TodoCategory
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public virtual Todo Todo { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
