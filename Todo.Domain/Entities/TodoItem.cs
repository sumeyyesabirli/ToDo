using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
    }
}

