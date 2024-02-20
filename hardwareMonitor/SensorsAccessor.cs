using System;
using System.Collections.Generic;

namespace hardwareMonitor
{
    internal class SensorsAccessor
    {
        public static void getCpuDataToString(ref string buffer)
        {
            if (Parametres.GET_CPU_TEMPERATURE)
            {
                List<Temperature> result = CPU.GetCpuTemperature();
                foreach (Temperature temperature in result)
                {
                    buffer += ComputersManager.Types.CPU + ":   " + temperature.Temp + (Parametres.IS_BIG_MODE ? "\n" : "    ");
                }
            }
            if (Parametres.GET_CPU_LOAD && !Parametres.IS_BIG_MODE)
            {
                int load = (int)Math.Round(CPU.GetCPULoad());
                buffer += load + "%\n";
            }
            else if (!Parametres.IS_BIG_MODE) buffer += '\n';
        }

        public static void getGpuDataToString(ref string buffer)
        {
            if (Parametres.GET_GPU_TEMPERATURE)
            {
                List<Temperature> result = GPU.GetGpuTemperature();
                foreach (Temperature temperature in result)
                {
                    buffer += ComputersManager.Types.GPU + ":   " + temperature.Temp + (Parametres.IS_BIG_MODE ? "\n" : "    ");
                }
            }
            if (Parametres.GET_GPU_LOAD && !Parametres.IS_BIG_MODE)
            {
                int load = (int)Math.Round(GPU.GetGPULoad());
                buffer += load + "%\n";
            }
            else if (!Parametres.IS_BIG_MODE) buffer += '\n';
        }


        public static void getSsdDataToString(ref string buffer)
        {

            if (Parametres.GET_SSD_TEMPERATURE && !Parametres.IS_BIG_MODE)
            {
                List<Temperature> result = SSD.GetSsdTemperature();
                foreach (Temperature temperature in result)
                {
                    buffer += ComputersManager.Types.SSD + ":   " + temperature.Temp + "\n";
                }
            }
        }

        public static void getRamDataToString(ref string buffer)
        {
            if (Parametres.GET_RAM_USAGE && !Parametres.IS_BIG_MODE)
            {
                List<RAM.RAMUsage> result = RAM.GetRamUsage();
                foreach (RAM.RAMUsage usage in result)
                {
                    int roundedLoad = (int)Math.Round(usage.Load);
                    buffer += "RAM:        " + roundedLoad + "%" + "\n";
                }
            }
        }
    }
}
