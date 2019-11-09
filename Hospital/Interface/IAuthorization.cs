using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Interface
{
    public interface IAuthorization
    {
        int Authoriz(string login,string password);
    }
}
