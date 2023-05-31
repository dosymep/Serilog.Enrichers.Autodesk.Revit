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
    /// Default revit addin property name.
    /// </summary>
    public const string RevitAddinPropertyName = "RevitAddin";
    
    /// <summary>
    /// Default revit document title property name.
    /// </summary>
    public const string RevitDocumentTitlePropertyName = "RevitDocumentTitle";
    
    /// <summary>
    /// Default revit document path name property name.
    /// </summary>
    public const string RevitDocumentPathNamePropertyName = "RevitDocumentPathName";
    
    /// <summary>
    /// Default revit document model path property name.
    /// </summary>
    public const string RevitDocumentModelPathPropertyName = "RevitDocumentModelPath";

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
    
    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/4cee7916-d799-fc83-daf3-97cb03900b72.htm">Document.Title</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitDocumentTitlePropertyName">Revit document title name. Default is <see cref="RevitDocumentTitlePropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitDocumentTitle(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitDocumentTitlePropertyName = RevitDocumentTitlePropertyName) {
        return loggerEnrichmentConfiguration.With(new DocumentTitlePropertyEnricher(revitDocumentTitlePropertyName, uiApplication));
    }
    
    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2022/8a92a6fd-ce25-cd86-2068-f9dcb24d72d6.htm">Document.PathName</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitDocumentPathNamePropertyName">Revit document path name. Default is <see cref="RevitDocumentPathNamePropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitDocumentPathName(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitDocumentPathNamePropertyName = RevitDocumentPathNamePropertyName) {
        return loggerEnrichmentConfiguration.With(new DocumentPathNamePropertyEnricher(revitDocumentPathNamePropertyName, uiApplication));
    }
    
    /// <summary>
    /// Enrich log events with a ModelPath property.
    /// <br/>If <a href="https://www.revitapidocs.com/2020/e12f7980-ba6c-2e72-6687-f0bf807ff014.htm">Document.IsModelInCloud</a> is true enriches <a href="https://www.revitapidocs.com/2020/087a7c14-1a6e-7022-c47b-923e90f4c5be.htm">Document.GetCloudModelPath()</a>.
    /// <br/>If <a href="https://www.revitapidocs.com/2017.1/7f368167-6543-9be9-67a3-c6e1696ae060.htm">Document.IsWorkshared</a> is true enriches <a href="https://www.revitapidocs.com/2017.1/6d42ee05-5738-8685-2165-57f9809f3161.htm">Document.GetWorksharingCentralModelPath()</a>.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitDocumentModelPathPropertyName">Revit document model path. Default is <see cref="RevitDocumentModelPathPropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitDocumentModelPath(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitDocumentModelPathPropertyName = RevitDocumentModelPathPropertyName) {
        return loggerEnrichmentConfiguration.With(new DocumentModelPathPropertyEnricher(revitDocumentModelPathPropertyName, uiApplication));
    }
    
    /// <summary>
    /// Enrich log events with a <a href="https://www.revitapidocs.com/2017.1/08272796-d8b8-8122-c712-08b108184334.htm">ActiveAddinId</a> property.
    /// </summary>
    /// <param name="loggerEnrichmentConfiguration">Logger enrichment configuration.</param>
    /// <param name="uiApplication">Revit UIApplication.</param>
    /// <param name="revitAddinPropertyName">Revit adin id. Default is <see cref="RevitAddinPropertyName"/>.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithRevitAddinId(this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration,
        UIApplication uiApplication,
        string revitAddinPropertyName = RevitAddinPropertyName) {
        return loggerEnrichmentConfiguration.With(new RevitAddinIdPropertyEnricher(revitAddinPropertyName, uiApplication));
    }

    internal static LoggerConfiguration WithRevitProperty<T>(
        this LoggerEnrichmentConfiguration loggerEnrichmentConfiguration, string propertyName, T propertyValue) {
        if(loggerEnrichmentConfiguration == null) {
            throw new ArgumentNullException(nameof(loggerEnrichmentConfiguration));
        }

        return loggerEnrichmentConfiguration.With(new RevitCachedPropertyEnricher<T>(propertyName, propertyValue));
    }
}