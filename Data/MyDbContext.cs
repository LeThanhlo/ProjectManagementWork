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
using Container_App.Model.Dto;
using Container_App.Model.Menus;

namespace Container_App.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<RefreshTokenModel> RefreshTokens { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUserInvite> ProjectUserInvites { get; set; }

        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<UserPermission> userPermission { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserPermissionDto> UserPermissionDto { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>()
            .HasNoKey();

            modelBuilder.Entity<UserPermissionDto>()
                .HasNoKey();
        }
    }
}
