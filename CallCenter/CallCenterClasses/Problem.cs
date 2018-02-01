using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace CallCenter.CallCenterClasses
{
    public abstract class Problem
    {

        protected string IDOperatera = WindowsIdentity.GetCurrent().Name.ToString();

        protected string MyConnectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        

    }
}
