using hardwareMonitor;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;

        public Form1()
        {
            InitializeComponent();
            jsonParser.getParamsFromFile(Parametres.jsonPath);
            SetControlValues();
            hardwareMonitor.Monitor.InitializeMonitor();

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Your Application Name";
            trayIcon.Icon = new Icon(@"C:\hardwareMonitor\icon.ico");
            trayIcon.Visible = false;

            trayIcon.DoubleClick += (s, e) =>
            {
                Show();
                WindowState = FormWindowState.Normal;
                trayIcon.Visible = false;
            };

            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemExit = new MenuItem("Выход");
            menuItemExit.Click += MenuItemExit_Click;
            contextMenu.MenuItems.Add(menuItemExit);
            trayIcon.ContextMenu = contextMenu;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                trayIcon.Visible = true;
            }
            else
            {
                hardwareMonitor.Monitor.StopMonitor();
                jsonParser.setParamsToFile(Parametres.jsonPath);
                base.OnFormClosing(e);
            }
        }


        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            hardwareMonitor.Monitor.StopMonitor();
            jsonParser.setParamsToFile(Parametres.jsonPath);
            Application.Exit();
        }


        private void btnStartStopMonitor_Click(object sender, EventArgs e)
        {
            if (hardwareMonitor.Monitor.IsMonitorRunning())
            {
                SerialPortManager.SerialPortSendMesage(ArduinoInterfaceManager.START_SEPARATE +
                                                        "paused" + ArduinoInterfaceManager.END_SEPARATE);
                hardwareMonitor.Monitor.StopMonitor();
                btnStartStopMonitor.Text = "Start Monitor";
            }
            else
            {
                hardwareMonitor.Monitor.InitializeMonitor();
                btnStartStopMonitor.Text = "Stop Monitor";
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void SetControlValues()
        {
            if (Parametres.DELAY_MULTIPLE == 0)
            {
                numDelay.Value = Convert.ToInt32(Parametres.DELAY / 1000);
            }
            else
            {
                numDelay.Value = Convert.ToInt32(Parametres.DELAY / Parametres.DELAY_MULTIPLE);
            }
            txtSerialPort.Text = Parametres.SERIAL_PORT;
            chkBigMode.Checked = Parametres.IS_BIG_MODE;
            chkCpuTemperature.Checked = Parametres.GET_CPU_TEMPERATURE;
            chkCpuLoad.Checked = Parametres.GET_CPU_LOAD;
            chkGpuTemperature.Checked = Parametres.GET_GPU_TEMPERATURE;
            chkGpuLoad.Checked = Parametres.GET_GPU_LOAD;
            chkRamUsage.Checked = Parametres.GET_RAM_USAGE;
            chkSsdTemperature.Checked = Parametres.GET_SSD_TEMPERATURE;
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            if (hardwareMonitor.Monitor.IsMonitorRunning())
            {
                hardwareMonitor.Monitor.StopMonitor();
            }
            Parametres.SERIAL_PORT = txtSerialPort.Text;

            if (Parametres.DELAY_MULTIPLE == 0)
            {
                Parametres.DELAY = (int)Convert.ChangeType(numDelay.Value * 1000, typeof(int));
            }
            else
            {
                Parametres.DELAY = (int)Convert.ChangeType(numDelay.Value * Parametres.DELAY_MULTIPLE, typeof(int));
            }
            Parametres.IS_BIG_MODE = chkBigMode.Checked;
            Parametres.GET_CPU_TEMPERATURE = chkCpuTemperature.Checked;
            Parametres.GET_CPU_LOAD = chkCpuLoad.Checked;
            Parametres.GET_GPU_TEMPERATURE = chkGpuTemperature.Checked;
            Parametres.GET_GPU_LOAD = chkGpuLoad.Checked;
            Parametres.GET_RAM_USAGE = chkRamUsage.Checked;
            Parametres.GET_SSD_TEMPERATURE = chkSsdTemperature.Checked;
            jsonParser.setParamsToFile(Parametres.jsonPath);
            if (!hardwareMonitor.Monitor.IsMonitorRunning())
            {
                hardwareMonitor.Monitor.InitializeMonitor();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                hardwareMonitor.Parametres.jsonPath = openFileDialog.FileName;
            }
        }

    }
}
