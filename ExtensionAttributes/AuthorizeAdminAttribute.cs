using GCommon.Models;
using Microsoft.AspNetCore.Authorization;

namespace GCommon.ExtensionAttributes
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        public AuthorizeAdminAttribute() : base()
        {
            this.Roles = enum_AppRoles.Administrator;
            
        }
    }
}
