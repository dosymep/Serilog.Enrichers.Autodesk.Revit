using Autodesk.Revit.UI;

using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Autodesk.Revit; 

internal class DocumentTitlePropertyEnricher : ILogEventEnricher {
    private readonly string _propertyName;
    private readonly UIApplication _uiApplication;

    public DocumentTitlePropertyEnricher(string propertyName, UIApplication uiApplication) {
        _propertyName = propertyName;
        _uiApplication = uiApplication;
    }
    
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(_propertyName, 
            _uiApplication.ActiveUIDocument?.Document.Title));
    }
}