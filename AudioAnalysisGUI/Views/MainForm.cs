using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioAnalysisGUI.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Load saved settings (if applicable)
            txtWorkingDirectory.Text = Properties.Settings.Default.WorkingDirectory;
            txtWhiteNoiseFile.Text = Properties.Settings.Default.WhiteNoiseFile;
            txtSineWaveFile.Text = Properties.Settings.Default.SineWaveFile;
            txtExecutablePath.Text = Properties.Settings.Default.ExecutablePath;
        }

        private void SaveSettings()
        {
            // Save current settings
            Properties.Settings.Default.WorkingDirectory = txtWorkingDirectory.Text;
            Properties.Settings.Default.WhiteNoiseFile = txtWhiteNoiseFile.Text;
            Properties.Settings.Default.SineWaveFile = txtSineWaveFile.Text;
            Properties.Settings.Default.ExecutablePath = txtExecutablePath.Text;
            Properties.Settings.Default.Save();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();
            base.OnFormClosing(e);
        }

        private void UpdateUiForAnalysis(bool isRunning)
        {
            // Update text box colors
            var textBoxColor = isRunning ? Color.FromArgb(60, 63, 65) : Color.FromArgb(50, 54, 62);
            txtWorkingDirectory.BackColor = textBoxColor;
            txtWhiteNoiseFile.BackColor = textBoxColor;
            txtSineWaveFile.BackColor = textBoxColor;
            txtExecutablePath.BackColor = textBoxColor;

            // Make text boxes read-only during analysis
            txtWorkingDirectory.ReadOnly = isRunning;
            txtWhiteNoiseFile.ReadOnly = isRunning;
            txtSineWaveFile.ReadOnly = isRunning;
            txtExecutablePath.ReadOnly = isRunning;

            // Update progress bar color
            progressBar.ForeColor = isRunning ? Color.LimeGreen : Color.FromArgb(70, 130, 180);
            progressBar.BackColor = isRunning ? Color.FromArgb(40, 44, 52) : Color.WhiteSmoke;

            // Enable/disable Run Analysis button
            btnRunAnalysis.Enabled = !isRunning;

            // Show progress bar only when running
            progressBar.Visible = isRunning;
        }

        private async void BtnRunAnalysis_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please ensure all paths are correctly specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update UI to indicate analysis is running
            UpdateUiForAnalysis(true);

            try
            {
                await RunAnalysisAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset UI after analysis completes
                UpdateUiForAnalysis(false);
            }
        }

        private bool ValidateInputs()
        {
            // Validate that all inputs are provided
            return Directory.Exists(txtWorkingDirectory.Text)
                && File.Exists(txtWhiteNoiseFile.Text)
                && File.Exists(txtSineWaveFile.Text)
                && File.Exists(txtExecutablePath.Text);
        }

        private async Task RunAnalysisAsync()
        {
            var workingDirectory = txtWorkingDirectory.Text;
            var whiteNoiseFile = txtWhiteNoiseFile.Text;
            var sineWaveFile = txtSineWaveFile.Text;
            var executablePath = txtExecutablePath.Text;

            // Create output directory with timestamp
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var outputDirectory = Path.Combine(workingDirectory, timestamp);
            Directory.CreateDirectory(outputDirectory);

            // Build command-line arguments
            var arguments = $"-exp_dir \"{outputDirectory}\" -wn \"{whiteNoiseFile}\" -sine \"{sineWaveFile}\"";

            // Run the executable asynchronously
            await Task.Run(() => ExecuteProcess(executablePath, arguments));
        }

        private void ExecuteProcess(string executablePath, string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = executablePath,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = startInfo };
            process.OutputDataReceived += (sender, e) => AppendLog(e.Data);
            process.ErrorDataReceived += (sender, e) => AppendLog("[ERROR] " + e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();
        }

        private void AppendLog(string? message)
        {
            if (message == null) return;

            if (rtxtOutputLogs.InvokeRequired)
            {
                rtxtOutputLogs.Invoke(new Action<string>(AppendLog), message);
            }
            else
            {
                rtxtOutputLogs.AppendText(message + Environment.NewLine);
            }
        }

        private void BtnBrowseWorkingDirectory_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtWorkingDirectory.Text = dialog.SelectedPath;
            }
        }

        private void BtnBrowseWhiteNoiseFile_Click(object sender, EventArgs e)
        {
            BrowseFile(txtWhiteNoiseFile);
        }

        private void BtnBrowseSineWaveFile_Click(object sender, EventArgs e)
        {
            BrowseFile(txtSineWaveFile);
        }

        private void BtnBrowseExecutable_Click(object sender, EventArgs e)
        {
            BrowseFile(txtExecutablePath);
        }

        private void BrowseFile(TextBox textBox)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = dialog.FileName;
            }
        }
    }
}
