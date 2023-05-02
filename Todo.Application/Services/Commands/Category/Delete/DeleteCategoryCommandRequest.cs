using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Commands.Category.Delete
{
    public class DeleteCategoryCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
