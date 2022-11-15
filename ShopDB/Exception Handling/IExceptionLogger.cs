using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Exception_Handling
{
    public interface IExceptionLogger
    {
        void Log(Exception exception);
    }
}
