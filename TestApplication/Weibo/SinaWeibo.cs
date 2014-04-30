using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jeff.Weibo
{
    public class SinaWeibo : WeiboBase
    {

        public SinaWeibo(String appKey, String appSecret)
            : base(appKey, appSecret)
        {
            this.AUTHORIZE_URL = "https://api.weibo.com/oauth2/authorize";
            this.ACCESS_TOKEN_URL = "https://api.weibo.com/oauth2/access_token";
            this.CallbackUrl = "https://api.weibo.com/oauth2/default.html";
        }

        /// <summary>
        /// 登录微博，登录成功返回true，否则false
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool Login(string username, string password)
        {
            String code = RetrieveCode(username, password);

            if (String.IsNullOrEmpty(code))
            {
                return false;
            }

            RetrieveToken(code);

            if (this.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 发个博文，这个只是纯文字的，不能太长
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public override bool PostWeibo(string content)
        {
            if (!Connected)
            {
                return false;
            }

            if (content.Length > 140)
            {
                return false;
            }

            RestClient client = new RestClient("https://api.weibo.com/2/statuses");

            RestRequest request = new RestRequest("update.json", Method.POST);

            request.AddParameter("access_token", this._accessToken.access_token);
            request.AddParameter("status", content);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                String ret = response.Content;
                Console.WriteLine(content);
                return true;
            }
            else
            {
                String ret = response.Content;
                return false;
            }
        }

        /// <summary>
        /// 上传图片并发布一条新微博
        /// </summary>
        /// <param name="content">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="picture">要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
        /// <returns></returns>
        public override bool PostPicWeibo(String content, byte[] picture)
        {
            if (!Connected)
            {
                return false;
            }

            if (content.Length > 140)
            {
                return false;
            }

            bool ret = PostPictureToWeibo("https://upload.api.weibo.com/2/statuses/upload.json",
                this._accessToken.access_token,
                new WeiboParameter("status", content),
                new WeiboParameter("pic", picture));

            return ret;
        }

        #region 工具方法

        public String RetrieveCode(String passport, String password)
        {
            String retCode = String.Empty;

            CookieContainer cookieContainer = new CookieContainer();

            HttpWebRequest http = WebRequest.Create(AUTHORIZE_URL) as HttpWebRequest;

            http.Referer = GetAuthorizeURL();
            http.Method = "POST";
            http.ContentType = "application/x-www-form-urlencoded";
            http.AllowAutoRedirect = true;
            http.KeepAlive = true;
            http.CookieContainer = cookieContainer;

            string postBody = string.Format("action=submit&scope=all&withOfficalFlag=0&withOfficalAccount=&ticket=&isLoginSina=&response_type=code&regCallback=&redirect_uri={0}&client_id={1}&state=all&from=&with_cookie=&userId={2}&passwd={3}&display=js", Uri.EscapeDataString(string.IsNullOrEmpty(CallbackUrl) ? "" : CallbackUrl), Uri.EscapeDataString(this._appKey), Uri.EscapeDataString(passport), Uri.EscapeDataString(password));

            byte[] postData = Encoding.Default.GetBytes(postBody);
            http.ContentLength = postData.Length;

            using (Stream request = http.GetRequestStream())
            {
                try
                {
                    request.Write(postData, 0, postData.Length);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    request.Close();
                }
            }

            string code = string.Empty;
            try
            {
                using (HttpWebResponse response = http.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            try
                            {
                                String html = reader.ReadToEnd();

                                // "code":"9c63a031e499a504b6b5219928ba18fe"

                                if (html.IndexOf("code") > 0)
                                {
                                    html = html.Substring(html.IndexOf(":", html.IndexOf("code")) + 1).Trim();

                                    html = html.Substring(1, html.IndexOf("\"", 1) - 1);

                                    retCode = html;
                                }
                            }
                            catch { }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                    response.Close();
                }
            }
            catch (System.Net.WebException)
            {
                throw;
            }

            return retCode;
        }

        public string GetAuthorizeURL()
        {
            Dictionary<string, string> config = new Dictionary<string, string>()
			{
				{"client_id", _appKey},
				{"redirect_uri", CallbackUrl},
				{"response_type","code"},
				{"state",""},
				{"display","Client"},
			};

            UriBuilder builder = new UriBuilder(AUTHORIZE_URL);
            builder.Query = Utility.BuildQueryString(config);

            return builder.ToString();
        }

        public void RetrieveToken(String code)
        {
            RestClient client = new RestClient("https://api.weibo.com/oauth2/");

            RestRequest request = new RestRequest("access_token", Method.POST);

            request.AddParameter("client_id", this._appKey);
            request.AddParameter("client_secret", this._appSecret);
            request.AddParameter("grant_type", "authorization_code");

            request.AddParameter("redirect_uri", "https://api.weibo.com/oauth2/default.html");
            request.AddParameter("code", code);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                String content = response.Content;

                AccessToken token = (AccessToken)Newtonsoft.Json.JsonConvert.DeserializeObject(content, typeof(AccessToken));

                if (token != null && !String.IsNullOrEmpty(token.access_token))
                {
                    _accessToken = token;
                }
            }
            else
            {
                _accessToken = null;
            }
        }

        public bool PostPictureToWeibo(string url, String accessToken, params WeiboParameter[] parameters)
        {
            string rawUrl = string.Empty;
            UriBuilder uri = new UriBuilder(url);

            string result = string.Empty;

            HttpWebRequest http = WebRequest.Create(uri.Uri) as HttpWebRequest;
            http.ServicePoint.Expect100Continue = false;
            http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";

            if (!String.IsNullOrEmpty(accessToken))
            {
                http.Headers["Authorization"] = string.Format("OAuth2 {0}", accessToken);
            }

            http.Method = "POST";

            string boundary = Utility.GetBoundary();
            http.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            http.AllowWriteStreamBuffering = true;

            using (Stream request = http.GetRequestStream())
            {
                try
                {
                    var raw = Utility.BuildPostData(boundary, parameters);
                    request.Write(raw, 0, raw.Length);
                }
                finally
                {
                    request.Close();
                }
            }

            try
            {
                using (WebResponse response = http.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        try
                        {
                            result = reader.ReadToEnd();
                        }
                        catch (Exception ex)
                        {
                            // String.Format("{ \"error\" : \"{0}\" }", ex.Message)
                            return false;
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    response.Close();

                    if (result.IndexOf("original_pic") > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // String.Format("{ \"error\" : \"{0}\" }", ex.Message)
                return false;
            }
        }

        #endregion

    }
}
