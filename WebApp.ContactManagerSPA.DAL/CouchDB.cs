using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.ContactManagerSPA.DAL
{
    public class CouchDB
    {
        public string couchDbConnection { get; set; }
        public CouchDB(string couchDbConnection)
        {
            this.couchDbConnection = couchDbConnection;
        }

        public string CouchDbRequest(string url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.ContentType = "application/json; charset=utf-8";
            StreamReader responseReader = new StreamReader(myHttpWebRequest.GetResponse().GetResponseStream());
            return responseReader.ReadToEnd();
        }

        public string CouchDbPost(string data)
        {
            var result = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(couchDbConnection.ToString());
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                
                streamWriter.Write(data);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public string CouchDbDelete(string id, string rev)
        {
            var result = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create((couchDbConnection + "/" + id + "?rev=" + rev).ToString());
            request.ContentType = "application/json";
            request.Method = "DELETE";
            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
