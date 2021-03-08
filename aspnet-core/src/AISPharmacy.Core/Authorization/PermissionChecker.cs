using Abp.Authorization;
using AISPharmacy.Authorization.Roles;
using AISPharmacy.Authorization.Users;

namespace AISPharmacy.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
