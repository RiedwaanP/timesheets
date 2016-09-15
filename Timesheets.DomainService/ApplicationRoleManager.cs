using Microsoft.AspNet.Identity;
using Timesheets.Domain;

namespace Timesheets.DomainService
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create()
        {
            return new ApplicationRoleManager(new RoleStore());
        }
    }
}
