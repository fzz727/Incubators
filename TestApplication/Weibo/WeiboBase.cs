using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff.Weibo
{
    public abstract class WeiboBase
    {
        protected string AUTHORIZE_URL = String.Empty; // "https://api.weibo.com/oauth2/authorize";
        protected string ACCESS_TOKEN_URL = String.Empty; // "https://api.weibo.com/oauth2/access_token";
        protected string CallbackUrl = String.Empty; // "https://api.weibo.com/oauth2/access_token";

        protected string _appKey = String.Empty;
        protected string _appSecret = String.Empty;

        protected AccessToken _accessToken = null;

        public WeiboBase(String appKey, String appSecret)
        {
            this._appKey = appKey;
            this._appSecret = appSecret;
        }

        public abstract bool Login(String username, String password);

        public abstract bool PostWeibo(String content);

        public abstract bool PostPicWeibo(String content, byte[] picture);

        public bool Connected
        {
            get
            {
                return _accessToken != null && !String.IsNullOrEmpty(_accessToken.access_token);
            }
        }
    }
}
