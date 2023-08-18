using Clean.WinF.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean.WinF.Domain.DbContexts
{
    public class BlueprintContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public BlueprintContext(DbContextOptions<BlueprintContext> options) : base(options)
        { }
        public DbSet<DistributionList> DistributionLists { get; set; }
        public DbSet<DistributionListGroup> DistributionListGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
           .ToTable("Users");

            builder.Entity<Role>(a =>
            {
                a.Metadata.RemoveIndex(new[] { a.Property(r => r.NormalizedName).Metadata });
                a.ToTable("Roles");
            });

            builder.Entity<IdentityRoleClaim<int>>(b =>
            {
                b.ToTable("Role_Claim");
            });

            builder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.ToTable("User_Claim");
            });

            builder.Entity<IdentityUserToken<int>>(b =>
            {
                b.ToTable("User_Token");
            });

            builder.Entity<DistributionList>(d =>
            {
                d.HasKey(dbl => dbl.Id).HasName("Id");
                d.HasIndex(dbl => dbl.Id).IsUnique();
                d.ToTable("DistributionLists");
            });

            builder.Entity<DistributionListGroup>(dg =>
            {
                dg.HasKey(db_g => new { db_g.DistributionListId, db_g.GroupId });

                dg.HasOne(db_g => db_g.DistributionLists)
                .WithMany(db_g => db_g.DistributionListGroups)
                .HasForeignKey(u_gr => u_gr.DistributionListId)
                .IsRequired();

                dg.HasOne(db_g => db_g.Groups)
                .WithMany(r => r.DistributionListGroups)
                .HasForeignKey(u_gr => u_gr.GroupId)
                .IsRequired();

                dg.ToTable("DistributionList_Groups");
            });

            builder.Entity<Group>(g =>
            {
                g.HasKey(gr => gr.GroupId).HasName("GroupId");
                g.HasIndex(gr => gr.GroupId).IsUnique();
                g.ToTable("Groups");
            });

            builder.Entity<Permission>(g =>
            {
                g.HasKey(gr => gr.Id).HasName("PermissionId");
                g.HasIndex(gr => gr.Id).IsUnique();
                g.ToTable("Permissions");
            });

            builder.Entity<UserGroup>(userGroup =>
            {
                userGroup.HasKey(u_gr => new { u_gr.GroupId, u_gr.UserId });

                userGroup.HasOne(u_gr => u_gr.Groups)
                .WithMany(gr => gr.UserGroups)
                .HasForeignKey(u_gr => u_gr.GroupId)
                .IsRequired();

                userGroup.HasOne(u_gr => u_gr.Users)
                .WithMany(r => r.UserGroups)
                .HasForeignKey(u_gr => u_gr.UserId)
                .IsRequired();

                userGroup.ToTable("User_Group");
            });

            builder.Entity<RoleGroup>(roleGroup =>
            {
                roleGroup.HasKey(r_gr => new { r_gr.GroupId, r_gr.RoleId });

                roleGroup.HasOne(r_gr => r_gr.Group)
                .WithMany(gr => gr.RoleGroups)
                .HasForeignKey(r_gr => r_gr.GroupId)
                .IsRequired();

                roleGroup.HasOne(r_gr => r_gr.Roles)
                .WithMany(r => r.RoleGroups)
                .HasForeignKey(r_gr => r_gr.RoleId)
                .IsRequired();

                roleGroup.ToTable("Role_Group");
            });


            builder.Entity<RolePermission>(rolePermission =>
            {
                rolePermission.HasKey(r_p => new { r_p.RoleId, r_p.PermissionId });

                rolePermission.HasOne(r_p => r_p.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(r_p => r_p.PermissionId)
                .IsRequired();

                rolePermission.HasOne(r_p => r_p.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(r_p => r_p.RoleId)
                .IsRequired();

                rolePermission.ToTable("Role_Permission");
            });
        }
    }
}
