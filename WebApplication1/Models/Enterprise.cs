using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("enterprise")]
    public class Enterprise
    {
        [Key]
        [Column("enterprise_id")]
        public int EnterpriseId { get; set; }

        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("working_hours")]
        [StringLength(100)]
        public string WorkingHours { get; set; }
    }
}
