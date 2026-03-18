using GCommon.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Text;
using GCommon.Models;

namespace GCommon.Services
{
    public class LocalProfiles : ILocalProfiles
    {
        private UserManager<IdentityUser> _list = null;
        private RoleManager<IdentityRole> _roleManager = null;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //********************************************************************************
        public LocalProfiles(UserManager<IdentityUser> list, RoleManager<IdentityRole> rm, IHttpContextAccessor httpContextAccessor)
        {
            this._list = list;
            this._roleManager = rm;
            this._httpContextAccessor = httpContextAccessor;
        }
        #region управление на ролите

        //*****************************************************************************************
        IQueryable<IdentityRole> ILocalProfiles.GetRoles()
        {
            return
                this._roleManager.Roles;
        }
        //*****************************************************************************************
        async Task ILocalProfiles.CreateRole(string role_name)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = role_name
            };
            await this._roleManager.CreateAsync(role);
        }
        //*****************************************************************************************
        async Task<IdentityRole> ILocalProfiles.FindRoleByName(string rolename)
        {
            IdentityRole find = await this._roleManager.FindByNameAsync(rolename);
            return find;
        }
        //*****************************************************************************************

        async Task ILocalProfiles.DeleteRole(string id)
        {
            IdentityRole rl = await this._roleManager.FindByIdAsync(id);
            if (rl != null)
            {
                await this._roleManager.DeleteAsync(rl);
            }
        }
        #endregion

        //********************************************************************************
        async Task<string> ILocalProfiles.infoRoles()
        {
            StringBuilder sb = new StringBuilder();

            IdentityUser[] registerd = (this as ILocalProfiles).Get().ToArray();

            foreach (var k in registerd)
            {
                bool is_admin = await (this as ILocalProfiles).CheckInRole(k.Id, enum_AppRoles.Administrator.ToString());
                bool is_user = await (this as ILocalProfiles).CheckInRole(k.Id, enum_AppRoles.User.ToString());
                sb.Append($"User {k.Id} | {k.UserName} admin {is_admin} | User {is_user}").AppendLine();

            }


            return sb.ToString();
        }

        //********************************************************************************
        bool ILocalProfiles.IsLogged()
        {



            bool result = false;
            if (this._httpContextAccessor.HttpContext.User != null)
            {
                if (this._httpContextAccessor.HttpContext.User.Identity != null)
                {
                    result = this._httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
                }
            }
            return result;
        }
        //********************************************************************************
        IQueryable<IdentityUser> ILocalProfiles.Get()
        {
            return this._list.Users;
        }
        //********************************************************************************
        async Task<IdentityResult> ILocalProfiles.Create(DTO_LocalProfile detail)
        {
            var result = await this._list.CreateAsync
                 (
                     new IdentityUser()
                     {
                         UserName = detail.UserName,
                         Email = detail.Email
                     },
                     detail.Password
                 );
            return result;
        }
        //********************************************************************************
        async Task<IdentityResult> ILocalProfiles.Delete(string id)
        {
            IdentityResult result = null;
            IdentityUser tuser = await this._list.FindByIdAsync(id);
            if (tuser != null)
            {
                result = await this._list.DeleteAsync(tuser);
            }
            return result;
        }

        //********************************************************************************
        async Task<IdentityResult> ILocalProfiles.Update(DTO_LocalProfile detail)
        {
            IdentityResult result = null;
            IdentityUser find = await this._list.FindByIdAsync(detail.ID);
            if (find != null)
            {
                find.UserName = detail.UserName;
                find.Email = detail.Email;

                result = await this._list.UpdateAsync(find);

                result = await this._list.RemovePasswordAsync(find);
                result = await this._list.AddPasswordAsync(find, detail.Password);

            }

            return result;
        }
        //********************************************************************************

        async Task ILocalProfiles.AssignToRole(string user_id, string role_name)
        {
            IdentityUser local_user = await this._list.FindByIdAsync(user_id);
            if (local_user != null)
            {
                IdentityRole role = await (this as ILocalProfiles).FindRoleByName(role_name);
                if (role != null)
                {
                    await this._list.AddToRoleAsync(local_user, role_name);
                }
            }
        }
        //********************************************************************************

        async Task ILocalProfiles.DeleteFromRole(string user_id, string role_name)
        {
            IdentityUser local_user = await this._list.FindByIdAsync(user_id);
            if (local_user != null)
            {
                await this._list.RemoveFromRoleAsync(local_user, role_name);
            }
        }
        //********************************************************************************
        async Task<bool> ILocalProfiles.CheckInRole(string user_id, string role_name)
        {
            bool result = false;
            IdentityUser local_user = await this._list.FindByIdAsync(user_id);
            if (local_user != null)
            {
                result = await this._list.IsInRoleAsync(local_user, role_name);
            }
            return result;
        }
        //********************************************************************************

    }
}
