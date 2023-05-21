using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom8.Models
{
    [Table("Subject")]
     public class Subject
    {
        [Key]
        public string SubjectID { get; set; }
        public string SubjectName { get; set; } //prop
    }
}