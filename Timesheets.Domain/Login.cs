using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Domain
{
    public class Login
    {
        [Required]
        [Display(Name = "User")]
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "LoginProvider")]
        [Key]
        [Column(Order = 1)]
        public string LoginProvider { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "ProviderKey")]
        [Key]
        [Column(Order = 2)]
        public string ProviderKey { get; set; }

        [Display(Name = "User")]
        public virtual User User { get; set; }
    }
}
