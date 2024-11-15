using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AudioAnalysisGUI.Utilities;

public class InputValidator
{
    public static List<string> ValidateInputs(List<InputDefinition> inputs)
    {
        var errorMessages = new List<string>();

        foreach (var input in inputs)
        {
            if (!input.ValidationFunction(input.Path))
            {
                input.TextBox.BackColor = Color.LightPink;
                errorMessages.Add(input.ErrorMessage);
            }
            else
            {
                input.TextBox.BackColor = SystemColors.Window;
            }
        }

        return errorMessages;
    }
}

public class InputDefinition(string path, Func<string, bool> validationFunction, TextBox textBox, string errorMessage)
{
    public string Path { get; } = path;
    public Func<string, bool> ValidationFunction { get; } = validationFunction;
    public TextBox TextBox { get; } = textBox;
    public string ErrorMessage { get; } = errorMessage;
}
