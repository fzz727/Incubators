﻿using RestSharp;
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
    }
}
