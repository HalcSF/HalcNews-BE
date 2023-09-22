using Volo.Abp.Modularity;

namespace HalcNews;

[DependsOn(
    typeof(HalcNewsApplicationModule),
    typeof(HalcNewsDomainTestModule)
    )]
public class HalcNewsApplicationTestModule : AbpModule
{

}
