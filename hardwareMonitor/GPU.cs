using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace hardwareMonitor
{
    class GPU
    {
        public static Computer computer = null;

        public static List<Temperature> GetGpuTemperature()
        {
            List<Temperature> result = new List<Temperature>();
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia || hardwareItem.HardwareType == HardwareType.GpuAti)
                {
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            float temp = sensor.Value.HasValue ? sensor.Value.Value : -99.9f;


                            if (sensor.Name == "GPU Hot Spot")
                            {
                                result.Add(new Temperature(sensor.Name, temp));
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static float GetGPULoad()
        {
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia || hardwareItem.HardwareType == HardwareType.GpuAti)
                {
                    hardwareItem.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name == "GPU Core")
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
