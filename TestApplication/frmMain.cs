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
            String name = response2.Data[0].UserName;

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
    }
}
