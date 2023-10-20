﻿using HalcNews.Noticias;
using HalcNews.Temas;
using HalcNews.ListaNoticias;
using HalcNews.Fuentes;
using Volo.Abp.Domain.Entities;
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
using HalcNews.Notificaciones;
using HalcNews.Lecturas;
using HalcNews.Alertas;

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
    public DbSet<Theme> themes { get; set; }
    public DbSet<Noticia> noticias { get; set; }
    public DbSet<EListaNoticias> listaNoticias { get; set; }


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
        builder.Entity<New>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Noticas", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.Author).IsRequired().HasMaxLength(128);
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).IsRequired();
            b.Property(x => x.Content).IsRequired();
            b.Property(x => x.Date). IsRequired();
            b.Property(x => x.Url).IsRequired().HasMaxLength(128);
            b.Property(x => x.UrlImage).HasMaxLength(128);

            //Relación con Lectura

            b.HasMany(x => x.Lecturies)
                .WithOne(x => x.New)
                .HasForeignKey(x => x.NewId)
                .IsRequired();

        });

        //Entidad ListaNoticias
        builder.Entity<NewsListE>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "ListaNoticias", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Date).IsRequired().HasMaxLength(128);
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).IsRequired();
        });

        //Entidad Notificacion
        builder.Entity<Notification>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Notificaciones", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();

            /*
            b.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired();*/

            b.Property(x => x.Date).IsRequired();
            b.Property(x => x.Text).IsRequired().HasMaxLength(128);
            b.Property(x => x.Link).IsRequired();
        });

        //Entidad Fuente
        builder.Entity<Source>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Fuentes", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired();

            b.HasMany(x => x.News)
            .WithOne(x => x.Source)
            .HasForeignKey(x => x.SourceId)
            .IsRequired();
        });

        //Entidad Lectura
        builder.Entity<Lectury>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Lectura", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.DateLectury).IsRequired();
        });

        //Entidad Alerta
        builder.Entity<Alert>(b =>
        {
            b.ToTable(HalcNewsConsts.DbTablePrefix + "Alerta", HalcNewsConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Search).IsRequired().HasMaxLength(128);
            b.Property(x => x.DateFound).IsRequired();
            b.Property(x => x.isRead).IsRequired();

            b.HasMany(x => x.Notifications)
                .WithOne(x => x.Alert)
                .HasForeignKey(x => x.AlertID)
                .IsRequired();
        });
    }
}