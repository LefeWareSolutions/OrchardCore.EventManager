using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardCore.ManageEvents
{
    public class EventManagerPermissions : IPermissionProvider
    {
        public static readonly Permission ManageEvents = new Permission(nameof(ManageEvents), "Manage Events");
        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageEvents }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            yield return new PermissionStereotype
            {
                Name = "Administrator",
                Permissions = new[]
                {
                    ManageEvents,
                }
            };
        }
    }
}
