using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Enums;

namespace Todo.Application.Services.Commands.Category.Update
{
    public class UpdateCategoryCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

    }
}
