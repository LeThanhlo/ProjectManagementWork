using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Container_App.Model.Users;
using Container_App.Model.Tokens;
using Container_App.Model.Projects;
using Container_App.Model.ProjectUserInvites;
using Container_App.Model.Roles;
using Container_App.Model.ProjectUsers;

namespace Container_App.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RefreshTokenModel> RefreshTokens { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<ProjectUserInviteModel> ProjectUserInvites { get; set; }

        public DbSet<ProjectUserModel> ProjectUsers { get; set; }

        public DbSet<RoleGroupModel> RoleGroups { get; set; }
    }
}
