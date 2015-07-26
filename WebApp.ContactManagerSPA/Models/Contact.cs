using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.ContactManagerSPA.Infrastructure.Domain;

namespace WebApp.ContactManagerSPA.Models
{
    public class Contact:EntityBase<string>
    {
        [JsonProperty("_rev")]
        public string Revision { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; } = "contact";
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