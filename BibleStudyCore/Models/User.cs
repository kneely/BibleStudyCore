using System.ComponentModel.DataAnnotations;

namespace BibleStudyCore.Models
{
    public class User
    {
        [StringLength(256)]
        public string Email { get; set; }
        [Key]
        public string Id { get; set; }

    }
}
