using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Extensions
{
    public class ExtendedDbContext<TUser> : ExtendedDbContext<TUser, ExtendedRole, string, IdentityUserLogin, IdentityUserRole, IdentityPermission, IdentityRolePermission, IdentityUserClaim>
    where TUser : IdentityUser
    {
        #region Default Constructors

        public ExtendedDbContext()
            : base("DefaultConnection")
        {
        }

        public ExtendedDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public ExtendedDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        public ExtendedDbContext(DbCompiledModel model)
            : base(model)
        {
        }

        public ExtendedDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public ExtendedDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        #endregion
    }
    public class ExtendedDbContext<TUser,TRole> : ExtendedDbContext<TUser, TRole, string, IdentityUserLogin, IdentityUserRole, IdentityPermission,IdentityRolePermission, IdentityUserClaim>
        where TUser : IdentityUser
        where TRole: ExtendedRole
    {
        #region Default Constructors

        public ExtendedDbContext()
            : base("DefaultConnection")
        {
        }

        public ExtendedDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public ExtendedDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        public ExtendedDbContext(DbCompiledModel model)
            : base(model)
        {
        }

        public ExtendedDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public ExtendedDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        #endregion
    }
    public class ExtendedDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TPermission, TRolePermission, TUserClaim> :
        Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext
        <TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
    where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>
    where TRole : ExtendedRole<TKey, TUserRole, TRolePermission>
    where TPermission : IdentityPermission<TKey, TRolePermission>
    where TRolePermission : IdentityRolePermission<TKey>
    where TUserLogin : IdentityUserLogin<TKey>
    where TUserRole : IdentityUserRole<TKey>
    where TUserClaim : IdentityUserClaim<TKey>
    {
        #region Default Constructors

        public ExtendedDbContext()
            : base("DefaultConnection")
        {
        }

        public ExtendedDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public ExtendedDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        public ExtendedDbContext(DbCompiledModel model)
            : base(model)
        {
        }

        public ExtendedDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public ExtendedDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        #endregion

        public virtual IDbSet<TPermission> Permissions { get; set; }
        public override IDbSet<TRole> Roles { get; set; }
        public virtual IDbSet<TRolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<TPermission> permissionTable = modelBuilder.Entity<TPermission>();
            EntityTypeConfiguration<TRolePermission> rolePermissionTable = modelBuilder.Entity<TRolePermission>();
            EntityTypeConfiguration<TRole> roleTable = modelBuilder.Entity<TRole>();

            permissionTable.Property((Expression<Func<TPermission, string>>)(p => p.Name))
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_OriginAndName") { Order = 1, IsUnique = true }));
            permissionTable.Property((Expression<Func<TPermission, long>>)(p => p.Origin))
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_OriginAndName") { Order = 2, IsUnique = true }));
            permissionTable.Property(x => x.IsGlobal)
                .IsRequired();

            permissionTable.ToTable("Permissions");

            rolePermissionTable.HasKey(r => new
            {
                r.RoleId,
                r.PermissionId
            }).ToTable("RolePermissions");

            permissionTable
            .HasMany(x => x.Roles)
            .WithRequired()
            .HasForeignKey(x => x.PermissionId);

            roleTable
            .HasMany(x => x.Permissions)
            .WithRequired()
            .HasForeignKey(x => x.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}