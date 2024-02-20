using System.IO.Ports;

namespace hardwareMonitor
{
    internal class SerialPortManager
    {
        private static SerialPort _serialPort;

        public static void InitializeSerialPort(string serialPort, int baudRate)
        {
            try
            {
                _serialPort = new SerialPort(serialPort, baudRate);
                _serialPort.Open();
            }
            catch (System.IO.IOException e)
            {
                throw new System.IO.IOException("Ошибка при открытии порта: " + e.Message);
            }
        }

        public static void CloseSerialPort()
        {
            try
            {
                _serialPort.Close();
            }
            catch (System.IO.IOException e)
            {
                throw new System.IO.IOException("Ошибка при закрытии порта: " + e.Message);
            }
        }

        public static void SerialPortSendMesage(string message)
        {
            try
            {
                _serialPort.Write(message);
            }
            catch (System.IO.IOException e)
            {
                throw new System.IO.IOException("Ошибка при отправлении сообщения в порт: " + e.Message);
            }
        }
    }
}
