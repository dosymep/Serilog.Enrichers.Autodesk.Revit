using Autodesk.Revit.ApplicationServices;

using System.Globalization;

namespace Serilog.Utils;

internal static class UtilsExtensions {
    public static CultureInfo GetCultureInfo(this LanguageType languageType) {
        switch((int) languageType) {
            case 0: // LanguageType.English_USA
                return CultureInfo.GetCultureInfo("en-US");
            case 1: // LanguageType.German
                return CultureInfo.GetCultureInfo("de-DE");
            case 2: // LanguageType.Spanish
                return CultureInfo.GetCultureInfo("es");
            case 3: // LanguageType.French
                return CultureInfo.GetCultureInfo("fr-FR");
            case 4: // LanguageType.Italian
                return CultureInfo.GetCultureInfo("it-IT");
            case 5: // LanguageType.Dutch
                return CultureInfo.GetCultureInfo("nl-NL");
            case 6: // LanguageType.Chinese_Simplified
                return CultureInfo.GetCultureInfo("zh-CN");
            case 7: // LanguageType.Chinese_Traditional
                return CultureInfo.GetCultureInfo("zh-Hant");
            case 8: // LanguageType.Japanese
                return CultureInfo.GetCultureInfo("ja-JP");
            case 9: // LanguageType.Korean
                return CultureInfo.GetCultureInfo("ko-KR");
            case 10: // LanguageType.Russian
                return CultureInfo.GetCultureInfo("ru-RU");
            case 11: // LanguageType.Czech
                return CultureInfo.GetCultureInfo("cs-CZ");
            case 12: // LanguageType.Polish
                return CultureInfo.GetCultureInfo("pl-PL");
            case 13: // LanguageType.Hungarian
                return CultureInfo.GetCultureInfo("hu-HU");
            case 14: // LanguageType.Brazilian_Portuguese
                return CultureInfo.GetCultureInfo("pt-BR");
            case 15: // LanguageType.English_GB
                return CultureInfo.GetCultureInfo("en-GB");
            default:
                return CultureInfo.CurrentCulture;
        }
    }
}