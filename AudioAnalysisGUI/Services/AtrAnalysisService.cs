// AtrAnalysisService.cs

using System.ComponentModel;
using System.Diagnostics;

namespace AudioAnalysisGUI.Services;

public class AtrAnalysisService : IAtrAnalysisService
{
    public event Action<string>? OutputReceived;
    public event Action<string>? ErrorReceived;
    public event Action<string>? AnalysisFailed;
    public event Action? AnalysisCompleted;

    public async Task RunAnalysisAsync(string executablePath, string arguments)
    {
        var startInfo = CreateProcessStartInfo(executablePath, arguments);

        using var process = new Process { StartInfo = startInfo, EnableRaisingEvents = true };
        AttachProcessEventHandlers(process);

        StartProcess(process);

        await WaitForProcessExitAsync(process);

        if (process.ExitCode == 0)
        {
            AnalysisCompleted?.Invoke();
        }
        else
        {
            AnalysisFailed?.Invoke($"Process exited with code {process.ExitCode}");
        }
    }

    private static ProcessStartInfo CreateProcessStartInfo(string executablePath, string arguments)
    {
        return new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
        };
    }

    private void AttachProcessEventHandlers(Process process)
    {
        AttachDataReceivedHandlers(process);
        process.Exited += (s, e) => { /* Handled after process exit */ };
    }

    private void AttachDataReceivedHandlers(Process process)
    {
        process.OutputDataReceived += OnOutputDataReceived;
        process.ErrorDataReceived += OnErrorDataReceived;
    }

    private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            OutputReceived?.Invoke(e.Data);
        }
    }

    private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            ErrorReceived?.Invoke(e.Data);
        }
    }

    private void StartProcess(Process process)
    {
        try
        {
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }
        catch (Win32Exception ex)
        {
            ErrorReceived?.Invoke($"Failed to start process: {ex.Message}");
            AnalysisFailed?.Invoke(ex.Message);
        }
        catch (Exception ex)
        {
            ErrorReceived?.Invoke($"Unexpected error: {ex.Message}");
            AnalysisFailed?.Invoke(ex.Message);
        }
    }

    private static async Task WaitForProcessExitAsync(Process process)
    {
        await process.WaitForExitAsync();
    }
}
