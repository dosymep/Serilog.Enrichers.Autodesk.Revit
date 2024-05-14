using Serilog.Events;

namespace Serilog.Enrichers.Autodesk.Revit.Tests;

public class RevitCachedPropertyTests {
    [Test]
    public void CustomPropertyEnricherIsApplied() {
        var propertyName = "RevitPropertyName";
        var propertyValue = "RevitPropertyValue";

        var testSink = new TestSink();
        var log = new LoggerConfiguration()
            .Enrich.WithRevitProperty(propertyName, propertyValue)
            .WriteTo.Sink(testSink)
            .CreateLogger();

        log.Information(@"Hello, world!");

        Assert.That(testSink.LogEvent, Is.Not.Null);
        Assert.That(propertyValue, Is.EqualTo(GetScalarValue(testSink?.LogEvent, propertyName)));
    }

    private object? GetScalarValue(LogEvent? logEvent, string propertyName) {
        var property = logEvent?.Properties[propertyName];
        return ((ScalarValue?) property)?.Value;
    }
}