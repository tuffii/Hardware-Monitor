using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace hardwareMonitor
{
    public class jsonParser
    {
        public static object GetParameterValue(string filePath, string paramName)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(json);
                return jsonObject[paramName];
            }
            else
            {
                throw new Exception("Config file not found!");
            }
        }

        public static void SetParameterValue(string filePath, string paramName, object value)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(json);
                jsonObject[paramName] = JToken.FromObject(value);
                File.WriteAllText(filePath, jsonObject.ToString());
            }
            else
            {
                throw new Exception("Config file not found!");
            }

        }

        public static void getParamsFromFile(string filePath)
        {
            try
            {
                int delay = Convert.ToInt32(GetParameterValue(filePath, "DELAY"));
                int delayMultiple = Convert.ToInt32(GetParameterValue(filePath, "DELAY_MULTIPLE"));
                Parametres.DELAY = delay;
                Parametres.DELAY_MULTIPLE = delayMultiple;
                Parametres.IS_BIG_MODE = Convert.ToBoolean(GetParameterValue(filePath, "IS_BIG_MODE"));
                Parametres.GET_CPU_TEMPERATURE = Convert.ToBoolean(GetParameterValue(filePath, "GET_CPU_TEMPERATURE"));
                Parametres.GET_CPU_LOAD = Convert.ToBoolean(GetParameterValue(filePath, "GET_CPU_LOAD"));
                Parametres.GET_GPU_TEMPERATURE = Convert.ToBoolean(GetParameterValue(filePath, "GET_GPU_TEMPERATURE"));
                Parametres.GET_GPU_LOAD = Convert.ToBoolean(GetParameterValue(filePath, "GET_GPU_LOAD"));
                Parametres.GET_RAM_USAGE = Convert.ToBoolean(GetParameterValue(filePath, "GET_RAM_USAGE"));
                Parametres.GET_SSD_TEMPERATURE = Convert.ToBoolean(GetParameterValue(filePath, "GET_SSD_TEMPERATURE"));
                Parametres.SERIAL_PORT = Convert.ToString(GetParameterValue(filePath, "SERIAL_PORT"));
                Parametres.BAUD_RATE = Convert.ToInt32(GetParameterValue(filePath, "BAUD_RATE"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading config file: " + ex.Message);
            }
        }

        public static void setParamsToFile(string filePath)
        {
            try
            {
                SetParameterValue(filePath, "DELAY", Parametres.DELAY);
                SetParameterValue(filePath, "BIG_MODE", Parametres.IS_BIG_MODE);
                SetParameterValue(filePath, "GET_CPU_TEMPERATURE", Parametres.GET_CPU_TEMPERATURE);
                SetParameterValue(filePath, "GET_CPU_LOAD", Parametres.GET_CPU_LOAD);
                SetParameterValue(filePath, "GET_GPU_TEMPERATURE", Parametres.GET_GPU_TEMPERATURE);
                SetParameterValue(filePath, "GET_GPU_LOAD", Parametres.GET_GPU_LOAD);
                SetParameterValue(filePath, "GET_RAM_USAGE", Parametres.GET_RAM_USAGE);
                SetParameterValue(filePath, "GET_SSD_TEMPERATURE", Parametres.GET_SSD_TEMPERATURE);
                SetParameterValue(filePath, "SERIAL_PORT", Parametres.SERIAL_PORT);
                SetParameterValue(filePath, "BAUD_RATE", Parametres.BAUD_RATE);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading config file: " + ex.Message);
            }
        }
    }
}
