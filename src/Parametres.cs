﻿using System.IO;
using System;

namespace hardwareMonitor
{
    class Parametres
    {
        public static string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Params.json");

        public static bool IS_BIG_MODE = false;
        public static bool GET_CPU_TEMPERATURE = true;
        public static bool GET_CPU_LOAD = true;
        public static bool GET_GPU_TEMPERATURE = true;
        public static bool GET_GPU_LOAD = true;
        public static bool GET_RAM_USAGE = true;
        public static bool GET_SSD_TEMPERATURE = true;
        public static int DELAY = 5000;
        public static int DELAY_MULTIPLE = 1000;
        public static string SERIAL_PORT = "COM5";
        public static int BAUD_RATE = 9600;
    }
}


