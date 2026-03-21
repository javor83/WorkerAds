using GCommon.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6.Navigation
{
    public class AuthorizeAdminAttribute:AuthorizeAttribute
    {
        public AuthorizeAdminAttribute():base()
        {
            this.Roles = enum_AppRoles.Administrator;
        }
    }

    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public AuthorizeUserAttribute() : base()
        {
            this.Roles = enum_AppRoles.User;
        }
    }
}
