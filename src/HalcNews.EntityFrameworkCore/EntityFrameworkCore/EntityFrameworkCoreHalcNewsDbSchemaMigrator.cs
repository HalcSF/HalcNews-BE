using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HalcNews.Data;
using Volo.Abp.DependencyInjection;

namespace HalcNews.EntityFrameworkCore;

public class EntityFrameworkCoreHalcNewsDbSchemaMigrator
    : IHalcNewsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHalcNewsDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HalcNewsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HalcNewsDbContext>()
            .Database
            .MigrateAsync();
    }
}
