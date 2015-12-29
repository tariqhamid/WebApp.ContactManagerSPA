using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ContactManagerSPA.Infrastructure.Domain;

namespace WebApp.ContactManagerSPA.Models
{
    public class Account: EntityBase<string>
    {
        [JsonProperty("_rev")]
        public string Revision { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; } = "account";
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        public string PasswordHash { get; set; }
        [JsonProperty("salt")]
        public string Salt { get; set; }
    }
}