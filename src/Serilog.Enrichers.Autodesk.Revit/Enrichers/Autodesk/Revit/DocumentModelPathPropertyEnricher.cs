using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using Serilog.Core;
using Serilog.Events;
using Serilog.Utils;

namespace Serilog.Enrichers.Autodesk.Revit;

internal class DocumentModelPathPropertyEnricher : ILogEventEnricher {
    private readonly string _propertyName;
    private readonly UIApplication _uiApplication;

    public DocumentModelPathPropertyEnricher(string propertyName, UIApplication uiApplication) {
        _propertyName = propertyName;
        _uiApplication = uiApplication;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        if(_uiApplication.ActiveUIDocument?.Document.IsCloudModel() == true) {
            ModelPath? modelPath = _uiApplication.ActiveUIDocument.Document.GetCloudModelPath();
            string? modelVisiblePath = modelPath.ConvertModelPathString();
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(_propertyName, modelVisiblePath));
        } else if(_uiApplication.ActiveUIDocument?.Document.IsWorkshared == true) {
            ModelPath modelPath = _uiApplication.ActiveUIDocument.Document.GetWorksharingCentralModelPath();
            string? modelVisiblePath = modelPath.ConvertModelPathString();
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(_propertyName, modelVisiblePath));
        } else {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(_propertyName, null));
        }
    }
}