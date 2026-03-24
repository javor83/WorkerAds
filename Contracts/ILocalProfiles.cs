using Microsoft.AspNetCore.Identity;
using GCommon.Models;

namespace GCommon.Contracts
{

    public interface ILocalProfiles
    {
        IQueryable<IdentityUser> Get();

        Task<IdentityResult> Create(DTO_LocalProfile detail);

        Task<IdentityResult> Update(DTO_LocalProfile detail);

        Task<IdentityResult> Delete(string id);

        bool IsLogged();
        Task<bool> CheckInRole(string user_id, string role_name);

        bool InRoleAdmin();
        bool InRoleUser();

        string CurrentUserID();


        Task AssignToRole(string user_id, string role_name);

        Task DeleteFromRole(string user_id, string role_name);

       

        IQueryable<IdentityRole> GetRoles();

        Task CreateRole(string role_name);



        Task<IdentityRole> FindRoleByName(string rolename);


        Task DeleteRole(string id);


        Task<string> infoRoles();

    }
}
