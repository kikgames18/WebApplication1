using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("administrator")]
    public class Administrator
    {
        [Key]
        [Column("admin_id")]
        public int AdminId { get; set; }

        [Required]
        [Column("login")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("contact_info")]
        [StringLength(255)]
        public string ContactInfo { get; set; }
    }
}
