using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.REST.model
{
    public class UserInfo
    {
        public String UserGUID { get; set; }
        public String UserAccount { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int RoleID { get; set; }
        public int Status { get; set; }
    }
}
