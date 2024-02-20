using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace hardwareMonitor
{
    class RAM
    {
        public static Computer computer = null;

        public struct RAMUsage
        {
            public string Name { get; set; }
            public float Load { get; set; }

            public RAMUsage(string name, float load)
            {
                Name = name;
                Load = load;
            }
        }

        public static List<RAMUsage> GetRamUsage()
        {
            List<RAMUsage> result = new List<RAMUsage>();

            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.RAM)
                {
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name == "Memory")
                        {
                            float load = sensor.Value.HasValue ? sensor.Value.Value : 0.0f;
                            result.Add(new RAMUsage(sensor.Name, load));
                        }
                    }
                }
            }
            return result;
        }
    }
}
