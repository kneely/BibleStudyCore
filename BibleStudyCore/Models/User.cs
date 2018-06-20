using System.ComponentModel.DataAnnotations;

namespace BibleStudyCore.Models
{
    public class User
    {
        [Key]
        public int ProgressID { get; set; }
        public string Email { get; set; }
        public string Verse1 { get; set; }
        public string Verse2 { get; set; }
        public string Verse3 { get; set; }
        public string Verse4 { get; set; }


        //[Key]
        //public string Id { get; set; }

    }
}
