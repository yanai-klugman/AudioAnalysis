// InputValidationService.cs

namespace AudioAnalysisGUI.Services;

public static class InputValidationService
{
    public static bool ValidateWorkingDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public static bool ValidateFilePath(string path)
    {
        return File.Exists(path);
    }
}
