using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace HalcNews;

[Dependency(ReplaceServices = true)]
public class HalcNewsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HalcNews";
}
