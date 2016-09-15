using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Domain
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public void Add(User user)
        {
            if (Users.Contains(user))
            {
                throw new DomainLogicError("User already added").AsException();
            }
            this.Users.Add(user);
        }

        public void Remove(User user)
        {
            this.Users.Remove(user);
        }
    }
}
