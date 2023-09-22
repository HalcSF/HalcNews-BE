using HalcNews.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HalcNews.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HalcNewsEntityFrameworkCoreModule),
    typeof(HalcNewsApplicationContractsModule)
    )]
public class HalcNewsDbMigratorModule : AbpModule
{
}
