using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class ByteArratDesc : IDeserializer
    {

        public string DateFormat { get; set; }


        public string Namespace { get; set; }

        public string RootElement        {            get;            set;        }


        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            // response.Content;
            throw new NotImplementedException();
        }
    }
}
