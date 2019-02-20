using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveRxNET
{
    public class Heater
    {
        private delegate void TemperatureChanged(int temperature);
        private event TemperatureChanged TemperatureChangedEvent;

        private void ShowTemperature(int temperature)
        {
            Console.WriteLine($"当前温度: {temperature}");
        }

        private void MakeAlerm(int temperature)
        {
            Console.WriteLine($"嘟嘟嘟，当前水温{temperature}");
        }

        public void BoilWater()
        {
            TemperatureChangedEvent += ShowTemperature;
            TemperatureChangedEvent += MakeAlerm;
            Task.Run(() => Enumerable.Range(1, 100).ToList().ForEach((temperature) => TemperatureChangedEvent(temperature)));
        } 
    }
}
