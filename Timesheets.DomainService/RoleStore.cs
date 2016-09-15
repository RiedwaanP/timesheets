using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Timesheets.Database;
using Timesheets.Domain;

namespace Timesheets.DomainService
{
    public class RoleStore :
          IQueryableRoleStore<Role, int>,
          IRoleStore<Role, int>
    {
        private readonly DatabaseContext database;

        public RoleStore()
        {
            database = new DatabaseContext();
        }

        #region IQueryableRoleStore<Role, TKey>

        public IQueryable<Role> Roles
        {
            get { return database.Roles; }
        }

        #endregion IQueryableRoleStore<Role, TKey>

        #region IRoleStore<Role, TKey>

        public virtual Task CreateAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            database.Set<Role>().Add(role);
            return database.SaveChangesAsync();
        }

        public Task DeleteAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }


            database.Set<Role>().Remove(role);
            return database.SaveChangesAsync();
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            return database.Roles.FindAsync(roleId);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return database.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }

        public Task UpdateAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            database.Entry<Role>(role).State = EntityState.Modified;
            return database.SaveChangesAsync();
        }

        #endregion IRoleStore<Role, TKey>

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
