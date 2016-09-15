using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Timesheets.Domain
{
    public class User : IUser<UserKey>
    {
        private UserKey id = null;

        public User(string email, string firstName, string lastName)
            : this()
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            UserName = email;
            EmailConfirmed = true;
        }

        public User()
        {
            this.Roles = new HashSet<Role>();
            this.UserClaims = new HashSet<UserClaim>();
        }

        public UserKey Id
        {
            get { return this.id ?? (this.id = new UserKey(this.UserId)); }
        }

        [Required]
        [Display]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required()]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [StringLength(200)]
        [Display(Name = "PasswordHash")]
        public string PasswordHash { get; set; }

        [StringLength(100)]
        [Display(Name = "SecurityStamp")]
        public string SecurityStamp { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "LockoutEndDateUtc")]
        public Nullable<DateTime> LockoutEndDateUtc { get; set; }

        [Required]
        [Display(Name = "LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [Required]
        [Display(Name = "AccessFailedCount")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Logins")]
        public virtual ICollection<Login> Logins { get; set; }

        [Display(Name = "UserClaims")]
        public virtual ICollection<UserClaim> UserClaims { get; set; }

        [Display(Name = "Roles")]
        public virtual ICollection<Role> Roles { get; set; }

        [Display(Name = "Projects")]
        public virtual ICollection<Project> Projects { get; set; }

        [Display(Name = "Projects")]
        public virtual ICollection<TimesheetEntry> TimesheetEntries { get; set; }

        public bool HasRoles(string[] roles)
        {
            return Roles.Any(r => roles.Contains(r.Name));
        }

        [Display(Name = "Roles Assigned")]
        public string RolesList
        {
            get
            {
                return string.Join(", ", this.Roles);
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, UserKey> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }
    }

    public static class UserIdentityExtension
    {
        public static UserKey GetUserKey(this IIdentity identity)
        {
            var userKeyStr = (identity as ClaimsIdentity).FindFirstValue(ClaimTypes.NameIdentifier);
            return new UserKey(userKeyStr);
        }
    }
}
