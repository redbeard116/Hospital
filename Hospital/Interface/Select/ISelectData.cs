using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Interface.Select
{
    public interface ISelectData
    {
        bool Auth(string login, string password);
    }
}
