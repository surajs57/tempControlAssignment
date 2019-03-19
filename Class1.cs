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
        public delegate void tempDelegate(int val);
        public event tempDelegate tempEvent;
        public temperature()
        {
            this.tempEvent += alertMessage;
            this.tempEvent += recordTemp;
        }
        public virtual void OnTempratureEvent()
        {
            int count = 0;
            while(count<10)
            {
                Random random = new Random();
                int temprature = random.Next(10, 30);
                tempEvent(temprature);
                count++;
            }
            
        }
        private void alertMessage(int s)
        {
            if(s<16)
            {
                Console.WriteLine("Its getting cooler:\n Temprature: {0}\n Date and Time: {1} ", s, DateTime.Now);
                Console.WriteLine("------------------------------------------------------------");
            }
            
            else if (s > 24)
            {
                Console.WriteLine("Its getting hotter " + s);
                Console.WriteLine("------------------------------------------------------------");
            }
                
            else
            {
                Console.WriteLine("Temprature is okay " + s);
                Console.WriteLine("------------------------------------------------------------");

            }
            Console.ReadKey();


        }
        public void recordTemp(int s)
        {
            var information = new data
            {
                temp = s,
                date_time = (DateTime.Now).ToString()

            };
            record.Add(information);
        }
        public void reportGenerator()
        {
            Console.WriteLine("Temperature fluctuation report\n**********************************************************************");
            var info = from tempinfo in record
                       select tempinfo.temp;
            Console.WriteLine("Average temperature: {0}\n Max temperature: {1}\n Min temperature: {2}", info.Average(), info.Max(), info.Min());
            Console.ReadKey();
        }
    }

    class data
    {
        public int temp { get; set; }
        public string date_time { get; set; }

    }
}