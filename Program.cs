using System;
using System.Collections.Generic;
using System.Text;
using temperatureEvents;

class program
{
    public static void Main(string[] args)
    {
        temperature temp = new temperature();
        temp.OnTempratureEvent();
        temp.reportGenerator();
    }
}