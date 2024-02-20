using OpenHardwareMonitor.Hardware;
using System;

namespace hardwareMonitor
{
    internal class ComputersManager
    {
        private static bool IS_CPU_COMPUTER_OPEN = false;
        private static bool IS_GPU_COMPUTER_OPEN = false;
        private static bool IS_SSD_COMPUTER_OPEN = false;
        private static bool IS_RAM_COMPUTER_OPEN = false;
        public class Types
        {
            public static readonly string CPU = "CPU";
            public static readonly string GPU = "GPU";
            public static readonly string RAM = "RAM";
            public static readonly string SSD = "SSD";
        }

        public static void initComputers()
        {
            if (Parametres.GET_GPU_TEMPERATURE || Parametres.GET_GPU_LOAD)
            {
                initComputer(Types.GPU, ref GPU.computer);
            }
            if (Parametres.GET_CPU_TEMPERATURE || Parametres.GET_CPU_LOAD)
            {
                initComputer(Types.CPU, ref CPU.computer);
            }
            if (Parametres.GET_SSD_TEMPERATURE)
            {
                initComputer(Types.SSD, ref SSD.computer);
            }
            if (Parametres.GET_RAM_USAGE)
            {
                initComputer(Types.RAM, ref RAM.computer);
            }
        }

        public static void closeComputers()
        {
            if (Parametres.GET_GPU_TEMPERATURE || Parametres.GET_GPU_LOAD)
            {
                closeComputer(Types.GPU, ref GPU.computer);
            }
            if (Parametres.GET_CPU_TEMPERATURE || Parametres.GET_CPU_LOAD)
            {
                closeComputer(Types.CPU, ref CPU.computer);
            }
            if (Parametres.GET_SSD_TEMPERATURE)
            {
                closeComputer(Types.SSD, ref SSD.computer);
            }
            if (Parametres.GET_RAM_USAGE)
            {
                closeComputer(Types.RAM, ref RAM.computer);
            }
        }


        public static void initComputer(string type, ref Computer computer)
        {
            try
            {
                if (computer != null)
                {
                    throw new Exception("computer is already define (initComputer)");
                }

                computer = new Computer();
                if (type == Types.CPU && IS_CPU_COMPUTER_OPEN == false)
                {
                    computer.CPUEnabled = true;
                    IS_CPU_COMPUTER_OPEN = true;
                }
                else if (type == Types.GPU && IS_GPU_COMPUTER_OPEN == false)
                {
                    computer.GPUEnabled = true;
                    IS_GPU_COMPUTER_OPEN = true;
                }
                else if (type == Types.RAM && IS_RAM_COMPUTER_OPEN == false)
                {
                    computer.RAMEnabled = true;
                    IS_RAM_COMPUTER_OPEN = true;
                }
                else if (type == Types.SSD && IS_SSD_COMPUTER_OPEN == false)
                {
                    computer.HDDEnabled = true;
                    IS_SSD_COMPUTER_OPEN = true;
                }
                else
                {
                    throw new Exception("computer already define or unknown type: " + type);
                }
                computer.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void closeComputer(string type, ref Computer computer)
        {
            try
            {
                if (computer == null)
                {
                    throw new Exception("computer is already closed (initComputer)");
                }
                if (type == Types.CPU && IS_CPU_COMPUTER_OPEN == true)
                {
                    computer.CPUEnabled = false;
                    IS_CPU_COMPUTER_OPEN = false;
                }
                else if (type == Types.GPU && IS_GPU_COMPUTER_OPEN == true)
                {
                    computer.GPUEnabled = false;
                    IS_GPU_COMPUTER_OPEN = false;
                }
                else if (type == Types.RAM && IS_RAM_COMPUTER_OPEN == true)
                {
                    computer.RAMEnabled = false;
                    IS_RAM_COMPUTER_OPEN = false;
                }
                else if (type == Types.SSD && IS_SSD_COMPUTER_OPEN == true)
                {
                    computer.HDDEnabled = false;
                    IS_SSD_COMPUTER_OPEN = false;
                }
                else
                {
                    throw new Exception("unknown define type or computer is already closed (initComputer)");
                }
                computer.Close();
                computer = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
