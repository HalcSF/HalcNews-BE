using System;
using System.Collections.Generic;
using System.Text;
using HalcNews.Localization;
using Volo.Abp.Application.Services;

namespace HalcNews;

/* Inherit your application services from this class.
 */
public abstract class HalcNewsAppService : ApplicationService
{
    protected HalcNewsAppService()
    {
        LocalizationResource = typeof(HalcNewsResource);
    }
}
