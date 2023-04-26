using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Commands.Category.Insert
{
    public class InsertCategoryCommandRequest : IRequest<bool>
    {
         public string Description { get; set; }
    }
}
