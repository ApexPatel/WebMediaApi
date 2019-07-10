using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMediaApi.Models
{
    public class PersonModel
    {
         [JsonProperty("Id")]
        public string Id { get; set; }

         [JsonProperty("Name")]
        public string Name { get; set; }
        
    }
}