using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Enums;

namespace Todo.Core.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public Priority? Priority { get; set; }

    }
}

