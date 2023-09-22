using System.Threading.Tasks;

namespace HalcNews.Data;

public interface IHalcNewsDbSchemaMigrator
{
    Task MigrateAsync();
}
