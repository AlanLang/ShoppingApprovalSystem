using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ShoppingApprovalSystem.Localization
{
    public static class ShoppingApprovalSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ShoppingApprovalSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ShoppingApprovalSystemLocalizationConfigurer).GetAssembly(),
                        "ShoppingApprovalSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
