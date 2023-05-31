using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Autodesk.Revit; 

internal class RevitCachedPropertyEnricher<T> : ILogEventEnricher {
    private readonly string _propertyName;
    private readonly T _propertyValue;

    private LogEventProperty? _logEventProperty;

    public RevitCachedPropertyEnricher(string propertyName, T propertyValue) {
        if(string.IsNullOrEmpty(propertyName)) {
            throw new ArgumentException("Value cannot be null or empty.", nameof(propertyName));
        }

        _propertyName = propertyName;
        _propertyValue = propertyValue;
    }
    
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        _logEventProperty ??= propertyFactory.CreateProperty(_propertyName, _propertyValue);
        logEvent.AddPropertyIfAbsent(_logEventProperty);
    }
}