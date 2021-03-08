using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AISPharmacy.Localization
{
    public static class AISPharmacyLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AISPharmacyConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AISPharmacyLocalizationConfigurer).GetAssembly(),
                        "AISPharmacy.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
