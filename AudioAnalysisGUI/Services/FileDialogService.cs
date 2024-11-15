// FileDialogService.cs

namespace AudioAnalysisGUI.Services;

public static class FileDialogService
{
    public static string BrowseForFolder(string initialPath = "")
    {
        using var folderDialog = new FolderBrowserDialog
        {
            SelectedPath = initialPath
        };
        return folderDialog.ShowDialog() == DialogResult.OK ? folderDialog.SelectedPath : string.Empty;
    }

    public static string BrowseForFile(string filter, string title, string initialDirectory = "")
    {
        using var fileDialog = new OpenFileDialog
        {
            Filter = filter,
            Title = title,
            InitialDirectory = initialDirectory
        };
        return fileDialog.ShowDialog() == DialogResult.OK ? fileDialog.FileName : string.Empty;
    }
}
