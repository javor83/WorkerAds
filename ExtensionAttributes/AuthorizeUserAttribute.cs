using GCommon.Models;
using Microsoft.AspNetCore.Authorization;

namespace GCommon.ExtensionAttributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public AuthorizeUserAttribute() : base()
        {
            this.Roles = enum_AppRoles.User;
        }
    }
}
