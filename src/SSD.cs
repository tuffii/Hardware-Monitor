using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace hardwareMonitor
{
    class SSD
    {
        public static Computer computer = null;
      
        public static List<Temperature> GetSsdTemperature()
        {
            List<Temperature> result = new List<Temperature>();

            bool isFirstSensor = true;

            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.HDD)
                {
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            if (isFirstSensor)
                            {
                                isFirstSensor = false;
                            }
                            else
                            {
                                float temp = sensor.Value.HasValue ? sensor.Value.Value : -99.9f;
                                result.Add(new Temperature("SSD", temp));
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
