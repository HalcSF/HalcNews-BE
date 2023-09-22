using HalcNews.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HalcNews;

[DependsOn(
    typeof(HalcNewsEntityFrameworkCoreTestModule)
    )]
public class HalcNewsDomainTestModule : AbpModule
{

}
