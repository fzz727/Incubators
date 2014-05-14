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
    public class TencentWeibo
    {

        String accessToken = String.Empty;

        public TencentWeibo()
        {
            accessToken = "b452edc539ef9f27e443de94c452eea7";
        }

        /// <summary>
        /// 发个博文，这个只是纯文字的，不能太长
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool PostWeibo(string content)
        {

            if (content.Length > 140)
            {
                return false;
            }

            RestClient client = new RestClient("https://open.t.qq.com/api/t");

            RestRequest request = new RestRequest("add", Method.POST);

            request.AddParameter("content", content);
            request.AddParameter("format", "json");
            request.AddParameter("access_token", accessToken);
            request.AddParameter("oauth_consumer_key", 801498650);
            request.AddParameter("openid", "7F83548B38A7633FE386526E716F8022");
            request.AddParameter("oauth_version", "2.a");
            request.AddParameter("clientip", "10.10.7.185");
            request.AddParameter("scope", "all");

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
        public bool PostPicWeibo(String content, byte[] picture)
        {

            RestClient client = new RestClient("https://open.t.qq.com/api/t");

            RestRequest request = new RestRequest("add_pic", Method.POST);

            request.AlwaysMultipartFormData = true;

            request.AddParameter("content", content);
            request.AddParameter("format", "json");
            request.AddParameter("access_token", accessToken);
            request.AddParameter("oauth_consumer_key", 801498650);
            request.AddParameter("openid", "7F83548B38A7633FE386526E716F8022");
            request.AddParameter("oauth_version", "2.a");
            request.AddParameter("clientip", "10.10.7.185");
            request.AddParameter("scope", "all");
            request.AddFile("pic", picture, "image.png", "image/png");

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                String ret = response.Content;
                Console.WriteLine(ret);
                return true;
            }
            else
            {
                String ret = response.Content;
                return false;
            }

        }
    }
}
