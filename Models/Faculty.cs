using System.ComponentModel.DataAnnotations;
namespace BTLNhom8.Models
{
    public class Faculty
    {
        [Key]
        public string FacultyID {get; set; }
        public string FacultyName { get; set; }
    }
}