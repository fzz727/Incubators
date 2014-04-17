using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRestUser_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://localhost:8080/miwps.web/services/api");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            RestRequest request = new RestRequest("hello/{id}", Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "admin"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            //request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            String content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            IRestResponse<List<REST.model.UserInfo>> response2 = client.Execute<List<REST.model.UserInfo>>(request);
            String name = response2.Data[0].userName;

            // easy async support
            //client.ExecuteAsync(request, response =>
            //{
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response =>
            //{
            //    Console.WriteLine(response.Data.Name);
            //});

            // abort the request on demand
            //asyncHandle.Abort();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://localhost:8080/miwps.web/services/api");

            RestRequest request = new RestRequest("save", Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new REST.model.UserInfo() { 
                userGUID = "1111", 
                userAccount = "test", 
                password = "password", 
                roleID = 4, 
                status = 0, 
                userName = "测试POST" 
            });

            IRestResponse response = client.Execute(request);
            String content = response.Content; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String s = System.IO.File.ReadAllText(Application.StartupPath + "\\report.json");

            RestClient client = new RestClient("http://localhost:8080/miwps.web/services/BllReportInfo");

            RestRequest request = new RestRequest("GetModel", Method.GET);
            request.AddParameter("reportID", 12190);

            IRestResponse response = client.Execute(request);

            String content = response.Content;

            int pO = content.IndexOf("DocxTemplate");

            int pS = content.IndexOf(":", pO)+1;
            int pE = content.IndexOf(",", pO);

            String strBase64 = content.Substring(pS, pE - pS).Trim(new Char[] { ' ', '"' });

            byte[] b = Convert.FromBase64String(strBase64);
            MessageBox.Show("ByteArray Length: " + b.Length.ToString());

            //client.AddHandler("application/json", new ByteArratDesc());

            //ReportInfo report = client.Execute<ReportInfo>(request).Data;


            ReportInfo report = (ReportInfo)Newtonsoft.Json.JsonConvert.DeserializeObject(content, typeof(ReportInfo));

            MessageBox.Show(report.ReportName);
        }

        private void btnLoginSinaWeibo_Click(object sender, EventArgs e)
        {

            String url = "https://api.weibo.com/oauth2/authorize?client_id=4140231521&redirect_uri=https://api.weibo.com/oauth2/default.html&scope=all&display=client";

            this.webBrowser1.Url = new System.Uri(url);

            this.webBrowser1.DocumentCompleted += (object ws, WebBrowserDocumentCompletedEventArgs we) => {

                String codeUrl = we.Url.AbsoluteUri;

                this.textBox1.AppendText(we.Url.AbsoluteUri + "\r\n");

                if (codeUrl.IndexOf("code") > 0)
                {
                    String code = codeUrl.Substring(codeUrl.IndexOf("code") + 5);

                    this.textBox1.AppendText(code + "\r\n");

                    RetrieveToken(code);
                }

            };

            int a = 1;
            if (a == 1)
            {
                return;
            }

            var oauth = new NetDimension.Weibo.OAuth("4140231521", "f52aeab2417234cc731c6b5fddca5257", "https://api.weibo.com/oauth2/default.html");

            NetDimension.Weibo.AccessToken token =  oauth.GetAccessTokenByPassword("fzz727@sina.com", "anj2lear");

            bool result = oauth.ClientLogin("fzz727@sina.com", "anj2lear");
            if (result) //返回true授权成功
            {
                Console.WriteLine(oauth.AccessToken); //还是来打印下AccessToken看看与前面方式获取的是不是一样的
                var Sina = new NetDimension.Weibo.Client(oauth);
                var uid = Sina.API.Dynamic.Account.GetUID(); //调用API中获取UID的方法
                Console.WriteLine(uid);
            }

            //var oauth = new NetDimension.Weibo.OAuth("4140231521", "f52aeab2417234cc731c6b5fddca5257", "https://api.weibo.com/oauth2/default.html");
            //var authUrl = oauth.GetAuthorizeURL();
            //System.Diagnostics.Process.Start(authUrl);


            
        }

        public void RetrieveToken(String code)
        {
            RestClient client = new RestClient("https://api.weibo.com/oauth2/");

            RestRequest request = new RestRequest("access_token", Method.POST);

            request.AddParameter("client_id", "4140231521");
            request.AddParameter("redirect_uri", "https://api.weibo.com/oauth2/default.html");
            request.AddParameter("scope", "all");
            request.AddParameter("display", "client");

            request.AddParameter("client_secret", "f52aeab2417234cc731c6b5fddca5257");
            request.AddParameter("grant_type", "authorization_code");

            request.AddParameter("code", code);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("OK: ");

                String content = response.Content;
                Console.WriteLine(content);

                MessageBox.Show(content);
            }
            else
            {
                String content = response.Content;
                Console.WriteLine("Failed: ");
                Console.WriteLine(content);

                MessageBox.Show(content);
            }
        }
    }
}
