using HalcNews.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HalcNews.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HalcNewsController : AbpControllerBase
{
    protected HalcNewsController()
    {
        LocalizationResource = typeof(HalcNewsResource);
    }
}
