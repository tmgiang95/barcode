using Clean.WinF.Domain.Entities;
using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.Entities.Languages;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Data.Sqlite;
using Clean.WinF.Domain.Entities.Menus;
using System.Reflection.Emit;
using System.Diagnostics;

namespace Clean.WinF.Infrastructure.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        //public ApplicationDBContext(DbContextOptionsBuilder<ApplicationDBContext> options) : base(options)
        //{ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //worked with sqlite
                var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "clean_winf_db.db" };
                var connectionString = connectionStringBuilder.ToString();
                var connection = new SqliteConnection(connectionString);
                optionsBuilder.UseSqlite(connection);

                //work with mysql
                //var connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                //var connStr = ConfigurationManager.AppSettings["DefaultConnection"];
                //optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr), context => context.MigrationsAssembly("Clean.WinF.Infrastructure"));

                //work with SQL server                           
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Access
            }
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Bobbin> Bobbins { get; set; }       
        public DbSet<Computer> Computers { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<ApplicationDefinition> ApplicationDefinitions { get; set; }
        public DbSet<AppGroupGUIDefinition> AppGroupGUIDefinitions { get; set; }
        public DbSet<AppCodeGUIDefinition> AppCodeGUIDefinitions { get; set; }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>().ToTable("Article");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<Supplier>().ToTable("Supplier");
            builder.Entity<Thread>().ToTable("Thread");
            builder.Entity<Report>().ToTable("Report");
            builder.Entity<Protocol>().ToTable("Protocol");
            builder.Entity<Part>().ToTable("Part");
            builder.Entity<Bobbin>().ToTable("Bobbin");            
            builder.Entity<Language>().ToTable("Language");
            builder.Entity<ApplicationDefinition>().ToTable("AppDefinition");
            builder.Entity<AppGroupGUIDefinition>().ToTable("AppGroupGUIDefinition");
            builder.Entity<AppCodeGUIDefinition>().ToTable("AppCodeGUIDefinition");

            //Menu tables
            builder.Entity<Menu>().ToTable("Menu");

            //user relationship tables
            //apply fluent API
            builder.Entity<Computer>()
           .HasOne<Setting>(s => s.Settings)
           .WithOne(c => c.Computers)
           .HasForeignKey<Setting>(st => st.ComputerID);

            builder.Entity<Setting>()
            .HasOne<Computer>(c => c.Computers)
            .WithOne(s => s.Settings)
            .HasForeignKey<Setting>(st => st.ComputerID);

            builder.Entity<User>(us => 
            {
                us.HasOne<UserGroup>(ug => ug.UserGroups)
                .WithMany(g => g.Users)
                .HasForeignKey(ugr => ugr.UserGroupID)
                .IsRequired();
                us.ToTable("User");
            });

            builder.Entity<UserGroup>(usrgroup =>
            {
                usrgroup.HasMany<User>(us => us.Users)
                .WithOne(ug => ug.UserGroups)
                .HasForeignKey(us => us.UserGroupID)
                .OnDelete(DeleteBehavior.Cascade);

                usrgroup.HasMany<Permission>(per => per.Permissions)
               .WithOne(ug => ug.UserGroups)
               .HasForeignKey(us => us.UserGroupID)
               .OnDelete(DeleteBehavior.Cascade);

                usrgroup.ToTable("UserGroup");
            });

            builder.Entity<Permission>(us =>
            {
                us.HasOne<UserGroup>(ug => ug.UserGroups)
                .WithMany(g => g.Permissions)
                .HasForeignKey(ugr => ugr.UserGroupID)
                .IsRequired();
                us.ToTable("Permission");
            });
        }
    }
}
