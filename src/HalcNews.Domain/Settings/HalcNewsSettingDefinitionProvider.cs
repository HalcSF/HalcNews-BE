using Volo.Abp.Settings;

namespace HalcNews.Settings;

public class HalcNewsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HalcNewsSettings.MySetting1));
    }
}
