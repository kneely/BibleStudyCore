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
        
        public string bookname { get; set; }
        public string chapter { get; set; }
        public string verse { get; set; }
        public string text { get; set; }
    }
}
