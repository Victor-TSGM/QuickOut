namespace QuickOut.Library;

/// <summary>
/// Verifica se o usuário tem permissão para acessar a função com o privilegio ou role. 
/// Caso o PrivilegeOrRole seja = 0, então vai apenas verificar se o usuário está logado
/// </summary>
public class AuthorizePrivilegeAttribute : Attribute
{
    public int PrivilegeOrRole { get; set; }

    public AuthorizePrivilegeAttribute()
    {
        PrivilegeOrRole = 0;
    }

    public AuthorizePrivilegeAttribute(int privilegesOrRoles)
    {
        PrivilegeOrRole = privilegesOrRoles;
    }

    public bool IsAuthorized(IEnumerable<int>? privilegesOrRoles)
    {
        if (privilegesOrRoles == null) {
            return false;
        }
        
        if (PrivilegeOrRole == 0) {
            return true;
        }

        return privilegesOrRoles.Contains(PrivilegeOrRole);
    }
}