using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Domain
{
    public class UserClaim
    {
        [Required]
        [Display(Name = "UserClaims")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserClaimsId { get; set; }

        [Required]
        [Display( Name = "User")]
        public int UserId { get; set; }

        [Display( Name = "ClaimType")]
        public string ClaimType { get; set; }

        [Display(Name = "ClaimValue")]
        public string ClaimValue { get; set; }

        [Display( Name = "User")]
        public virtual User User { get; set; }
    }
}
