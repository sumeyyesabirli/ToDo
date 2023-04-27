﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Enums;

namespace Todo.Application.Services.Queries.TodoItem.GetByFilterPriority
{
    public class GetByFilterPriorityQueriesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? UserId { get; set; }
        public Priority? Priority { get; set; }
    }
}
