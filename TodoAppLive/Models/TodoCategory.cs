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
        public Todo Todo { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
