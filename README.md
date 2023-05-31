# Serilog.Enrichers.Autodesk.Revit

The Autodesk Revit enrichers for [Serilog](https://serilog.net).

### Getting started

Install the [Serilog.Enrichers.Autodesk.Revit](https://www.nuget.org/packages/Serilog.Enrichers.Autodesk.Revit/) package from NuGet:

```powershell
Install-Package Serilog.Enrichers.Autodesk.Revit
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
// IExternalCommand.Execute
public Result Execute(ExternalCommandData commandData, 
                      out string message, 
                      ElementSet elements) {
    UIApplication uiApplication = commandData.Application;
    var log = new LoggerConfiguration()
        .Enrich.WithRevitVersion(uiApplication)
        // other enrichers..
        .CreateLogger();
}
```

```csharp
// IExternalApplication.Execute
public Result OnStartup(UIControlledApplication application) {
    var log = new LoggerConfiguration()
        .Enrich.WithRevitVersion(application)
        // other enrichers...
        .CreateLogger();
}
```

#### Included enrichers

The package includes:

- `WithRevitVersion()` - adds `Application.VersionNumber` or `ControlledApplication.VersionNumber`
- `WithRevitBuild()` - adds `Application.VersionBuild` or `ControlledApplication.VersionBuild`
- `WithRevitUserName()` - adds `Application.Username` or `ControlledApplication.Username`
- `WithRevitLanguage()` - adds `Application.Language` or `ControlledApplication.Language`
- `WithRevitDocumentTitle()` - adds `Document.Title`
- `WithRevitDocumentPathName()` - adds `Document.PathName`
- `WithRevitDocumentModelPath()` - adds `Document.GetCloudModelPath()` if `Document.IsModelInCloud` is `true` or `Document.GetWorksharingCentralModelPath()` if `Document.IsWorkshared` is `true`
- `WithRevitAddinId()` - adds `Application.ActiveAddinId`