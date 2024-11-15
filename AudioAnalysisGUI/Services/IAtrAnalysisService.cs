// IAtrAnalysisService.cs

namespace AudioAnalysisGUI.Services;

public interface IAtrAnalysisService
{
    event Action<string>? OutputReceived;
    event Action<string>? ErrorReceived;
    event Action? AnalysisCompleted;
    event Action<string>? AnalysisFailed;

    Task RunAnalysisAsync(string executablePath, string arguments);
}
