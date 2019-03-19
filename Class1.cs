using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temperatureEvents
{
    public class temperature
    {
        List<data> record = new List<data>();
        public delegate void tempDelegate(int val, string msg, string dateTime);
        public event tempDelegate tempEvent;
        public temperature()
        {
            this.tempEvent += alertMessage;
            this.tempEvent += recordTemp;
        }
        public virtual void OnTempratureEvent(int temperatureValue, int min,int max)
        {
            if(temperatureValue<min)
                tempEvent(temperatureValue, "Its getting cooler", (DateTime.Now).ToString());

            if (temperatureValue > max)
                tempEvent(temperatureValue, "Its getting hotter", (DateTime.Now).ToString());
            
        }
        private void alertMessage(int s, string m, string dt)
        {
            Console.WriteLine("\nAlert: {0}\n Temperature: {1}\n Date and Time : {2}", m, s, dt);
        }
        public void recordTemp(int s, string m, string dt)
        {
            var information = new data
            {
                temp = s,
                date_time = dt

            };
            record.Add(information);
        }
        public void reportGenerator()
        {
            Console.WriteLine("Temperature fluctuation report\n**********************************************************************");
            try
            {
                var info = from tempinfo in record
                           select tempinfo.temp;
                Console.WriteLine("Average temperature: {0}\n Max temperature: {1}\n Min temperature: {2}", info.Average(), info.Max(), info.Min());
                Console.ReadKey();
        }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Temperature is within range");
                Console.ReadKey();
            }

        }
    }

    class data
    {
        public int temp { get; set; }
        public string date_time { get; set; }

    }
}
