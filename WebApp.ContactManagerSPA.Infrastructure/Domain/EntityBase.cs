using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.ContactManagerSPA.Infrastructure.Domain
{
    public class EntityBase<TId>
    {
        [JsonProperty("_id")]
        public TId Id { get; set; }

    }
}
