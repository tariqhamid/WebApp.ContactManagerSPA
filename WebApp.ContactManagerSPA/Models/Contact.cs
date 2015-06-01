using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.ContactManagerSPA.Models
{
    public class Contact
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }
        [JsonProperty("_rev")]
        public string Revision { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [JsonProperty("telephone")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [JsonProperty("mobile")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
    }
}