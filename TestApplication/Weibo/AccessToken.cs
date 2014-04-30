using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff.Weibo
{
    /// <summary>
    /// {"access_token":"2.00a1g3bBl2zLWEcca6fbc41aL4dQnD","remind_in":"157679999","expires_in":157679999,"uid":"1468263204","scope":"all"}
    /// </summary>
    public class AccessToken
    {
        public String access_token { get; set; }
        public Int32 remind_in { get; set; }
        public Int32 expires_in { get; set; }
        public String uid { get; set; }
        public String scope { get; set; }
    }
}
