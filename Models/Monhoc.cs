using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom8.Models
{
    [Table("Monhoc")]
    public class Monhoc
    {
        [Key]
        public string Ma_mon {get; set; }
        public string Ten_mon { get; set; }

    }
}