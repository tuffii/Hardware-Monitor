namespace hardwareMonitor
{
    public struct Temperature
    {
        public string Name { get; set; }
        public float Temp { get; set; }
        public Temperature(string name, float temp)
        {
            Name = name;
            Temp = temp;
        }
    }
}
