using System;
using System.Collections.Generic;
using System.Text;
using temperatureEvents;

class program
{
    public static void Main(string[] args)
    {
        temperature temp = new temperature();
        int min=int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        int count = 0;
        while(count<10)
        {
            Random random = new Random();
            int temperature = random.Next(min-6, max+6);
            temp.OnTempratureEvent(temperature,min,max);
            count++;
        }
       
        temp.reportGenerator();
    }
}
