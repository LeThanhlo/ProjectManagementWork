﻿using Container_App.Model.UserRoles;

namespace Container_App.Repository.UserRoleRepository
{
    public interface IUserRoleRepository
    {
        Task<int> CreateUserRole(UserRole userRole);

        Task<int> CheckPermissionByUserIdAndTable(int userId, string tableName);
        Task<int> DeleteUserRole(int RoleId);
    }
}
