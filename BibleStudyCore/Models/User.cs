﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BibleStudyCore.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int ProgressID { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        public string Verse1 { get; set; }
      

        //Verse1.Replace(" ", "+");


        //[Key]
        //public string Id { get; set; }

    }
}
