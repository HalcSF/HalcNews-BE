using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HalcNews.Data;

/* This is used if database provider does't define
 * IHalcNewsDbSchemaMigrator implementation.
 */
public class NullHalcNewsDbSchemaMigrator : IHalcNewsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
