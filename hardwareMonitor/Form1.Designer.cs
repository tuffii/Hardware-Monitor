using System.Windows.Forms;

namespace WindowsFormsApp5
{
    partial class Form1
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 250);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

            InitializeControls();
        }

        private void InitializeControls()
        {
            btnStartStopMonitor = new System.Windows.Forms.Button();
            btnStartStopMonitor.Location = new System.Drawing.Point(100, 150);
            btnStartStopMonitor.Name = "btnStartStopMonitor";
            btnStartStopMonitor.Size = new System.Drawing.Size(100, 25);
            btnStartStopMonitor.Text = "Stop Monitor";
            btnStartStopMonitor.Click += new System.EventHandler(this.btnStartStopMonitor_Click);
            this.Controls.Add(btnStartStopMonitor);

            txtSerialPort = new System.Windows.Forms.TextBox();
            txtSerialPort.Location = new System.Drawing.Point(100, 30);
            txtSerialPort.Text = "COM3";
            this.Controls.Add(txtSerialPort);

            numDelay = new System.Windows.Forms.NumericUpDown();
            numDelay.Location = new System.Drawing.Point(100, 60);
            numDelay.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numDelay.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numDelay.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.Controls.Add(numDelay);

            chkBigMode = new System.Windows.Forms.CheckBox();
            chkBigMode.Location = new System.Drawing.Point(100, 90);
            chkBigMode.Text = "Big Mode";
            chkBigMode.Checked = false;
            this.Controls.Add(chkBigMode);

            chkCpuTemperature = new System.Windows.Forms.CheckBox();
            chkCpuTemperature.Location = new System.Drawing.Point(250, 30);
            chkCpuTemperature.Text = "Get CPU Temperature";
            chkCpuTemperature.Checked = true;
            this.Controls.Add(chkCpuTemperature);

            chkCpuLoad = new System.Windows.Forms.CheckBox();
            chkCpuLoad.Location = new System.Drawing.Point(250, 60);
            chkCpuLoad.Text = "Get CPU Load";
            chkCpuLoad.Checked = true;
            this.Controls.Add(chkCpuLoad);

            chkGpuTemperature = new System.Windows.Forms.CheckBox();
            chkGpuTemperature.Location = new System.Drawing.Point(250, 90);
            chkGpuTemperature.Text = "Get GPU Temperature";
            chkGpuTemperature.Checked = true;
            this.Controls.Add(chkGpuTemperature);

            chkGpuLoad = new System.Windows.Forms.CheckBox();
            chkGpuLoad.Location = new System.Drawing.Point(250, 120);
            chkGpuLoad.Text = "Get GPU Load";
            chkGpuLoad.Checked = true;
            this.Controls.Add(chkGpuLoad);

            chkRamUsage = new System.Windows.Forms.CheckBox();
            chkRamUsage.Location = new System.Drawing.Point(400, 30);
            chkRamUsage.Text = "Get RAM Usage";
            chkRamUsage.Checked = true;
            this.Controls.Add(chkRamUsage);

            chkSsdTemperature = new System.Windows.Forms.CheckBox();
            chkSsdTemperature.Location = new System.Drawing.Point(400, 60);
            chkSsdTemperature.Text = "Get SSD Temperature";
            chkSsdTemperature.Checked = true;
            this.Controls.Add(chkSsdTemperature);

            btnApplySettings = new System.Windows.Forms.Button();
            btnApplySettings.Location = new System.Drawing.Point(100, 200);
            btnApplySettings.Name = "btnApplySettings";
            btnApplySettings.Size = new System.Drawing.Size(100, 25);
            btnApplySettings.Text = "Apply Settings";
            btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);
            this.Controls.Add(btnApplySettings);

            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBrowse.Location = new System.Drawing.Point(350, 200);
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.Controls.Add(this.btnBrowse);
        }

        private Button btnStartStopMonitor;
        private Button btnBrowse;
        private Button btnApplySettings;
        private TextBox txtSerialPort;
        private NumericUpDown numDelay;
        private CheckBox chkBigMode;
        private CheckBox chkCpuTemperature;
        private CheckBox chkCpuLoad;
        private CheckBox chkGpuTemperature;
        private CheckBox chkGpuLoad;
        private CheckBox chkRamUsage;
        private CheckBox chkSsdTemperature;

    }
}
