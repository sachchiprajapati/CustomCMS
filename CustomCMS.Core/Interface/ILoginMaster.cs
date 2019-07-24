using CustomCMS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Core.Interface
{
    public interface ILoginMaster
    {
        Boolean IsLogin(LoginModel obj);
    }
}
