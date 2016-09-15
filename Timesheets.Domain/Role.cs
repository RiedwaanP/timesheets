using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Timesheets.Domain
{
    public class Role : IRole<int>
    {
        public const string Admin = "Admin";
        public const string Capturer = "Capturer";


        [Required]
        [Display( Name = "Role")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        [Display( Name = "Role Name")]
        public string Name { get; set; }

        [Display(Name = "Users")]
        public virtual ICollection<User> Users { get; set; }


        public int Id
        {
            get { return this.RoleId; }
        }

        public Role(string name)
            : this()
        {
            this.Name = name;
        }

        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
