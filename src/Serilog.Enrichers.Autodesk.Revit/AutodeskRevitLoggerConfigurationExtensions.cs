using Autodesk.Revit.UI;

using Serilog.Configuration;
using Serilog.Enrichers.Autodesk.Revit;
using Serilog.Utils;

namespace Serilog;

/// <summary>
/// Extends <see cref="LoggerSinkConfiguration"/>.
/// </summary>
public static class AutodeskRevitLoggerConfigurationExtensions {
    /// <summary>
    /// Default revit version property name.
    /// </summary>
    public const string RevitVersionPropertyName = "RevitVersion";

    /// <summary>
    /// Default revit build property name.
    /// </summary>
    public const string RevitBuildPropertyName = "RevitBuild";
    
    /// <summary>
    /// Default revit username property name.
    /// </summary>
    public const string RevitUserNamePropertyName = "RevitUserName";
    
    /// <summary>
    /// Default revit language property name.
    /// </summary>
    public const string RevitLanguagePropertyName = "RevitLanguage";

    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/320391bf-2c21-98ca-192c-da1d9becff11.htm">VersionNumber</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitVersionPropertyName">Revit version property name. Default is <see cref="RevitVersionPropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitVersion(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitVersionPropertyName = RevitVersionPropertyName) {
        return loggerEnrichmentConfiguration.WithRevitProperty(revitVersionPropertyName,
            int.Parse(uiApplication.Application.VersionNumber));
    }

    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/35b18b73-4c47-fee3-d2f9-21298f029f7f.htm">VersionNumber</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiControlledApplication">Revit UIControlledApplication.</param>
    /// <param name="revitVersionPropertyName">Revit version property name. Default is <see cref="RevitVersionPropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitVersion(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIControlledApplication uiControlledApplication,
        string revitVersionPropertyName = RevitVersionPropertyName) {
        return loggerEnrichmentConfiguration.WithRevitProperty(revitVersionPropertyName,
            int.Parse(uiControlledApplication.ControlledApplication.VersionNumber));
    }

    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/04ef312a-e25a-cbcd-40c4-43fe6311e677.htm">VersionBuild</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitBuildPropertyName">Revit build property name. Default is <see cref="RevitBuildPropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitBuild(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitBuildPropertyName = RevitBuildPropertyName) {
        return loggerEnrichmentConfiguration.WithRevitProperty(revitBuildPropertyName,
            uiApplication.Application.VersionBuild);
    }

    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/c5963cab-c85b-561b-1ea2-b9d11b58050c.htm">VersionBuild</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiControlledApplication">Revit UIControlledApplication.</param>
    /// <param name="revitBuildPropertyName">Revit build property name. Default is <see cref="RevitBuildPropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitBuild(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIControlledApplication uiControlledApplication,
        string revitBuildPropertyName = RevitBuildPropertyName) {
        return loggerEnrichmentConfiguration.WithRevitProperty(revitBuildPropertyName,
            uiControlledApplication.ControlledApplication.VersionBuild);
    }
    
    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/2a7c8664-de0d-7a43-e670-2e733e579609.htm">Username</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitUserNamePropertyName">Revit username property name. Default is <see cref="RevitUserNamePropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitUserName(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitUserNamePropertyName = RevitUserNamePropertyName) {
        return loggerEnrichmentConfiguration.WithRevitProperty(revitUserNamePropertyName,
            uiApplication.Application.Username);
    }
    
    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/2b1d8b80-a11c-2a57-63bd-6c0d67691879.htm">Language</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitLanguagePropertyName">Revit language property name. Default is <see cref="RevitLanguagePropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitLanguage(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitLanguagePropertyName = RevitLanguagePropertyName) {
        return loggerEnrichmentConfiguration.WithRevitProperty(revitLanguagePropertyName,
            uiApplication.Application.Language.GetCultureInfo().EnglishName);
    }

    internal static LoggerConfiguration WithRevitProperty<T>(
        this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration, string propertyName, T propertyValue) {
        if(loggerEnrichmentConfiguration == null) {
            throw new ArgumentNullException(nameof(loggerEnrichmentConfiguration));
        }

        return loggerEnrichmentConfiguration.With(new RevitCachedPropertyEnricher<T>(propertyName, propertyValue));
    }
}