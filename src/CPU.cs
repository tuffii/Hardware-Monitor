using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace hardwareMonitor
{
    class CPU
    {
        public static Computer computer = null;

        public static List<Temperature> GetCpuTemperature()
        {
            List<Temperature> result = new List<Temperature>();
            foreach (IHardware hrdw in computer.Hardware)
            {
                if (hrdw.HardwareType == HardwareType.CPU)
                {
                    hrdw.Update();
                    foreach (IHardware subhard in hrdw.SubHardware) subhard.Update();
                    foreach (ISensor sensor in hrdw.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            string nm = sensor.Name;
                            float tem = sensor.Value.HasValue ? sensor.Value.Value : -99.9f;

                            if (nm == "CPU Package")
                            {
                                result.Add(new Temperature(nm, tem));
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static float GetCPULoad()
        {
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    hardwareItem.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name == "CPU Total")
                        {
                            return sensor.Value ?? 0.0f;
                        }
                    }
                }
            }
            return -1.0f;
        }
    }
}