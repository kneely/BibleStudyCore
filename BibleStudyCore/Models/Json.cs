using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace BibleStudyCore.Models
{
    public class Json
    {
        [JsonProperty("bookname")]
        [BindNever]
        public string bookname { get; set; }

        [BindNever]
        [JsonProperty("chapter")]
        public string chapter { get; set; }

        [BindNever]
        [JsonProperty("verse")]
        public string verse { get; set; }

        [BindNever]
        [JsonProperty("text")]
        public string text { get; set; }

        [BindNever]
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
    }
}