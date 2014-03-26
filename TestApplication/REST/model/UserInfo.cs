using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.REST.model
{
    public class UserInfo
    {
        public String userGUID { get; set; }
        public String userAccount { get; set; }
        public String userName { get; set; }
        public String password { get; set; }
        public int roleID { get; set; }
        public int status { get; set; }
    }
}
