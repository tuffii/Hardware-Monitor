using hardwareMonitor;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hardwareMonitor
{
    internal class ArduinoInterfaceManager
    {
        public static readonly char START_SEPARATE = '{';
        public static readonly char END_SEPARATE = '}';
        public static readonly char LARGE_MODE_MARK = 'L';
        public static readonly char SMALL_MODE_MARK = 'S';

        public static void setArduinoInterface(bool isBigMode)
        {
            try
            {
                if (isBigMode)
                {
                    SerialPortManager.SerialPortSendMesage(new string(new char[] { START_SEPARATE, LARGE_MODE_MARK, END_SEPARATE }));
                }
                else
                {
                    SerialPortManager.SerialPortSendMesage(new string(new char[] { START_SEPARATE, SMALL_MODE_MARK, END_SEPARATE }));
                }
            }
            catch (Exception e)
            {
                throw new System.IO.IOException("IOException set interface ARDUINO error: " + e);
            }
        }
    }
}
