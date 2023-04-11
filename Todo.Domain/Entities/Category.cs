using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Entities
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
