using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Token
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minute);
    }
}
