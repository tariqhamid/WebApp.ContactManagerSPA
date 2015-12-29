using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ContactManagerSPA.Models
{
    public class Response
    {
        [JsonProperty("ok")]
        public string Status { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("rev")]
        public string Revision { get; set; }
        [JsonIgnore]
        public string Message { get; set; }
    }
}