﻿using HalcNews.Noticias;
using HalcNews.Temas;
using HalcNews.ListaNoticias;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace HalcNews.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class HalcNewsDbContext :
    AbpDbContext<HalcNewsDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion


    #region Entidades de dominio
    public DbSet<Theme> Themes { get; set; }

    #endregion

    public HalcNewsDbContext(DbContextOptions<HalcNewsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(HalcNewsConsts.DbTablePrefix + "YourEntities", HalcNewsConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        //Entidad Theme
        builder.Entity<Theme>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Themes", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention(); 
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        //Entidad Noticia
        builder.Entity<Noticia>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Noticas", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne(x => x.Fuente)
            .WithMany()
            .HasForeignKey(x => x.FuenteId)
            .IsRequired();

            b.Property(x => x.Autor).IsRequired().HasMaxLength(128);
            b.Property(x => x.Titulo).IsRequired().HasMaxLength(128);
            b.Property(x => x.Descripcion).IsRequired();
            b.Property(x => x.Contenido).IsRequired();
            b.Property(x => x.Fecha). IsRequired();
            b.Property(x => x.Url).IsRequired().HasMaxLength(128);
            b.Property(x => x.UrlImagen).HasMaxLength(128);

            //Relación con Lectura

            b.HasMany(x => x.Lecturas)
                .WithOne(x => x.Noticia)
                .HasForeignKey(x => x.NoticiasId)
                .IsRequired();

        });

        //Entidad ListaNoticias
        builder.Entity<EListaNoticias>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "ListaNoticias", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Fecha).IsRequired().HasMaxLength(128);
            b.Property(x => x.Titulo).IsRequired().HasMaxLength(128);
            b.Property(x => x.Descripcion).IsRequired();
        });

        //Entidad Notificacion
        builder.Entity<Notificacion>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Notificaciones", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired();

            b.HasOne(x => x.Alerta)
            .WithMany()
            .HasForeignKey(x => x.AlertaId)
            .IsRequired();

            b.Property(x => x.Fecha).IsRequired();
            b.Property(x => x.Texto).IsRequired().HasMaxLength(128);
            b.Property(x => x.Link).IsRequired().HasMaxLenght(128);
        });

        //Entidad Fuente
        builder.Entity<Fuente>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Fuentes", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.Noticia)
            .WithOne(x => x.Fuente)
            .HasForeignKey(x => x.FuenteId)
            .IsRequired();
        })

        //Entidad Lectura
        builder.Entity<Lectura>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Lectura", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.fechaLectura).IsRequired();

        });

        //Entidad Alerta
        builder.Entity<Alerta>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Alerta", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Busqueda).IsRequired().HasMaxLength(128);
            b.Property(x => x.FechaEncontrada).IsRequired();
            b.Property(x => x.Leida).IsRequired();
        });
    }
}