// MainForm.Designer.cs

using System;
using System.Drawing;
using System.Windows.Forms;

namespace AudioAnalysisGUI.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtWorkingDirectory;
        private System.Windows.Forms.TextBox txtWhiteNoiseFile;
        private System.Windows.Forms.TextBox txtSineWaveFile;
        private System.Windows.Forms.TextBox txtExecutablePath;
        private System.Windows.Forms.Button btnBrowseWorkingDirectory;
        private System.Windows.Forms.Button btnBrowseWhiteNoiseFile;
        private System.Windows.Forms.Button btnBrowseSineWaveFile;
        private System.Windows.Forms.Button btnBrowseExecutable;
        private System.Windows.Forms.Button btnRunAnalysis;
        private System.Windows.Forms.RichTextBox rtxtOutputLogs;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblWorkingDirectory;
        private System.Windows.Forms.Label lblWhiteNoiseFile;
        private System.Windows.Forms.Label lblSineWaveFile;
        private System.Windows.Forms.Label lblExecutablePath;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Initialize controls
            this.txtWorkingDirectory = new TextBox();
            this.txtWhiteNoiseFile = new TextBox();
            this.txtSineWaveFile = new TextBox();
            this.txtExecutablePath = new TextBox();
            this.btnBrowseWorkingDirectory = new Button();
            this.btnBrowseWhiteNoiseFile = new Button();
            this.btnBrowseSineWaveFile = new Button();
            this.btnBrowseExecutable = new Button();
            this.btnRunAnalysis = new Button();
            this.rtxtOutputLogs = new RichTextBox();
            this.progressBar = new ProgressBar();
            this.lblWorkingDirectory = new Label();
            this.lblWhiteNoiseFile = new Label();
            this.lblSineWaveFile = new Label();
            this.lblExecutablePath = new Label();

            // Form properties
            this.ClientSize = new Size(1200, 800);
            this.Text = "Audio Analysis ATR Tool";
            this.MinimumSize = new Size(1200, 800);
            this.BackColor = Color.FromArgb(40, 44, 52); // One Dark Pro background
            this.ForeColor = Color.FromArgb(171, 178, 191); // One Dark Pro foreground

            // Labels
            this.lblWorkingDirectory.Text = "Working Directory:";
            this.lblWorkingDirectory.Location = new Point(20, 30);
            this.lblWorkingDirectory.Size = new Size(200, 40);
            this.lblWorkingDirectory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

            this.lblWhiteNoiseFile.Text = "White Noise File:";
            this.lblWhiteNoiseFile.Location = new Point(20, 100);
            this.lblWhiteNoiseFile.Size = new Size(200, 40);
            this.lblWhiteNoiseFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

            this.lblSineWaveFile.Text = "Sine Wave File:";
            this.lblSineWaveFile.Location = new Point(20, 170);
            this.lblSineWaveFile.Size = new Size(200, 40);
            this.lblSineWaveFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

            this.lblExecutablePath.Text = "Executable Path:";
            this.lblExecutablePath.Location = new Point(20, 240);
            this.lblExecutablePath.Size = new Size(200, 40);
            this.lblExecutablePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

            // TextBoxes
            this.txtWorkingDirectory.Location = new Point(230, 30);
            this.txtWorkingDirectory.Size = new Size(850, 40);
            this.txtWorkingDirectory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtWorkingDirectory.BackColor = Color.FromArgb(50, 54, 62);
            this.txtWorkingDirectory.ForeColor = Color.FromArgb(171, 178, 191);
            this.txtWorkingDirectory.BorderStyle = BorderStyle.FixedSingle;

            this.txtWhiteNoiseFile.Location = new Point(230, 100);
            this.txtWhiteNoiseFile.Size = new Size(850, 40);
            this.txtWhiteNoiseFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtWhiteNoiseFile.BackColor = Color.FromArgb(50, 54, 62);
            this.txtWhiteNoiseFile.ForeColor = Color.FromArgb(171, 178, 191);
            this.txtWhiteNoiseFile.BorderStyle = BorderStyle.FixedSingle;

            this.txtSineWaveFile.Location = new Point(230, 170);
            this.txtSineWaveFile.Size = new Size(850, 40);
            this.txtSineWaveFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtSineWaveFile.BackColor = Color.FromArgb(50, 54, 62);
            this.txtSineWaveFile.ForeColor = Color.FromArgb(171, 178, 191);
            this.txtSineWaveFile.BorderStyle = BorderStyle.FixedSingle;

            this.txtExecutablePath.Location = new Point(230, 240);
            this.txtExecutablePath.Size = new Size(850, 40);
            this.txtExecutablePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtExecutablePath.BackColor = Color.FromArgb(50, 54, 62);
            this.txtExecutablePath.ForeColor = Color.FromArgb(171, 178, 191);
            this.txtExecutablePath.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            this.btnBrowseWorkingDirectory.Location = new Point(1090, 30);
            this.btnBrowseWorkingDirectory.Size = new Size(90, 40);
            this.btnBrowseWorkingDirectory.Text = "Browse";
            this.btnBrowseWorkingDirectory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnBrowseWorkingDirectory.BackColor = Color.FromArgb(66, 70, 78);
            this.btnBrowseWorkingDirectory.ForeColor = Color.FromArgb(171, 178, 191);
            this.btnBrowseWorkingDirectory.Click += new EventHandler(this.BtnBrowseWorkingDirectory_Click);

            this.btnBrowseWhiteNoiseFile.Location = new Point(1090, 100);
            this.btnBrowseWhiteNoiseFile.Size = new Size(90, 40);
            this.btnBrowseWhiteNoiseFile.Text = "Browse";
            this.btnBrowseWhiteNoiseFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnBrowseWhiteNoiseFile.BackColor = Color.FromArgb(66, 70, 78);
            this.btnBrowseWhiteNoiseFile.ForeColor = Color.FromArgb(171, 178, 191);
            this.btnBrowseWhiteNoiseFile.Click += new EventHandler(this.BtnBrowseWhiteNoiseFile_Click);

            this.btnBrowseSineWaveFile.Location = new Point(1090, 170);
            this.btnBrowseSineWaveFile.Size = new Size(90, 40);
            this.btnBrowseSineWaveFile.Text = "Browse";
            this.btnBrowseSineWaveFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnBrowseSineWaveFile.BackColor = Color.FromArgb(66, 70, 78);
            this.btnBrowseSineWaveFile.ForeColor = Color.FromArgb(171, 178, 191);
            this.btnBrowseSineWaveFile.Click += new EventHandler(this.BtnBrowseSineWaveFile_Click);

            this.btnBrowseExecutable.Location = new Point(1090, 240);
            this.btnBrowseExecutable.Size = new Size(90, 40);
            this.btnBrowseExecutable.Text = "Browse";
            this.btnBrowseExecutable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnBrowseExecutable.BackColor = Color.FromArgb(66, 70, 78);
            this.btnBrowseExecutable.ForeColor = Color.FromArgb(171, 178, 191);
            this.btnBrowseExecutable.Click += new EventHandler(this.BtnBrowseExecutable_Click);

            this.btnRunAnalysis.Location = new Point(20, 300);
            this.btnRunAnalysis.Size = new Size(1160, 50);
            this.btnRunAnalysis.Text = "Run Analysis";
            this.btnRunAnalysis.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRunAnalysis.BackColor = Color.FromArgb(52, 73, 94);
            this.btnRunAnalysis.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnRunAnalysis.Click += new EventHandler(this.BtnRunAnalysis_Click);

            // RichTextBox
            this.rtxtOutputLogs.Location = new Point(20, 370);
            this.rtxtOutputLogs.Size = new Size(1160, 360);
            this.rtxtOutputLogs.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.rtxtOutputLogs.BackColor = Color.FromArgb(40, 44, 52);
            this.rtxtOutputLogs.ForeColor = Color.FromArgb(171, 178, 191);
            this.rtxtOutputLogs.ReadOnly = true;

            // ProgressBar
            this.progressBar.Location = new Point(20, 750);
            this.progressBar.Size = new Size(1160, 30);
            this.progressBar.ForeColor = Color.FromArgb(70, 130, 180);
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;

            // Add controls to the form
            this.Controls.Add(this.lblWorkingDirectory);
            this.Controls.Add(this.txtWorkingDirectory);
            this.Controls.Add(this.btnBrowseWorkingDirectory);
            this.Controls.Add(this.lblWhiteNoiseFile);
            this.Controls.Add(this.txtWhiteNoiseFile);
            this.Controls.Add(this.btnBrowseWhiteNoiseFile);
            this.Controls.Add(this.lblSineWaveFile);
            this.Controls.Add(this.txtSineWaveFile);
            this.Controls.Add(this.btnBrowseSineWaveFile);
            this.Controls.Add(this.lblExecutablePath);
            this.Controls.Add(this.txtExecutablePath);
            this.Controls.Add(this.btnBrowseExecutable);
            this.Controls.Add(this.btnRunAnalysis);
            this.Controls.Add(this.rtxtOutputLogs);
            this.Controls.Add(this.progressBar);

            this.ResumeLayout(false);
        }
    }
}
