using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Autodesk.Revit.Tests; 

internal class TestSink : ILogEventSink {
    public LogEvent? LogEvent = null;
    
    public void Emit(LogEvent logEvent) {
        LogEvent = logEvent;
    }
}