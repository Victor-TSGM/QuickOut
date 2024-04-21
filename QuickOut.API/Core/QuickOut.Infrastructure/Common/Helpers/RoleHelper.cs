using QuickOut.Domain.Common.Interfaces;
using QuickOut.Domain.Common.Shared;

namespace QuickOut.Infrastructure.Common;

public class RoleHelper
{
    public static List<int> GetPrivilegesFromRole(UserRole role)
    {
        switch (role)
        {
            case UserRole.Administrator:
                return new List<int>() {
                    Privileges.Administrator
                };
            case UserRole.Customer:
                return new List<int>()
                {
                    Privileges.Customer
                };
            default:
                return new List<int>();
        }
    }
}