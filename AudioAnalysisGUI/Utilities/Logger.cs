using System;
using System.Windows.Forms;

namespace AudioAnalysisGUI.Utilities;
public class Logger
{
    private readonly RichTextBox _outputBox;

    public Logger(RichTextBox outputBox)
    {
        _outputBox = outputBox ?? throw new ArgumentNullException(nameof(outputBox));
    }

    public void Log(string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        if (_outputBox.InvokeRequired)
        {
            _outputBox.Invoke(new Action<string>(Log), message);
        }
        else
        {
            _outputBox.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
            _outputBox.ScrollToCaret();
        }
    }

    public void Clear()
    {
        if (_outputBox.InvokeRequired)
        {
            _outputBox.Invoke(new Action(Clear));
        }
        else
        {
            _outputBox.Clear();
        }
    }
}

