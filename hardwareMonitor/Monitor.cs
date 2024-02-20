using System;
using System.Threading;

namespace hardwareMonitor
{
    internal class Monitor
    {
        private static Thread _monitorThread;
        private static bool _monitorRunning = false;

        public static void InitializeMonitor()
        {
            if (IsMonitorRunning())
            {
                Console.WriteLine("Monitor already start");
                return;
            }
            try
            {
                SerialPortManager.InitializeSerialPort(Parametres.SERIAL_PORT, Parametres.BAUD_RATE);
                ArduinoInterfaceManager.setArduinoInterface(Parametres.IS_BIG_MODE);
                ComputersManager.initComputers();

                _monitorThread = new Thread(MonitoringMainProcess);
                _monitorThread.IsBackground = true;
                _monitorRunning = true;
                _monitorThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Start monitor error: " + e.Message);
            }
        }

        public static void StopMonitor()
        {
            if (!IsMonitorRunning())
            {
                Console.WriteLine("Monitor already stop");
                return;
            }
            _monitorRunning = false;
            _monitorThread.Join();
            try
            {
                ComputersManager.closeComputers();
                SerialPortManager.CloseSerialPort();
            }
            catch (Exception e)
            {
                Console.WriteLine("Stop monitor error: " + e.Message);
            }
        }

        private static void MonitoringMainProcess()
        {
            while (IsMonitorRunning())
            {
                string dataToSend = ArduinoInterfaceManager.START_SEPARATE.ToString();

                SensorsAccessor.getCpuDataToString(ref dataToSend);
                SensorsAccessor.getGpuDataToString(ref dataToSend);
                SensorsAccessor.getSsdDataToString(ref dataToSend);
                SensorsAccessor.getRamDataToString(ref dataToSend);

                dataToSend += ArduinoInterfaceManager.END_SEPARATE;

                SerialPortManager.SerialPortSendMesage(dataToSend);
                if (IsMonitorRunning())
                {
                    Thread.Sleep(Parametres.DELAY);
                }
            }
        }
        public static bool IsMonitorRunning()
        {
            return _monitorRunning;
        }
    }
}
