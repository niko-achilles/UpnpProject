using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpnpSwitch;

namespace UpnpConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("UPnP .NET Framework Console Client");

            SwitchPower device = new SwitchPower();
            device.Start();
            System.Console.WriteLine("Press return to stop device.");
            System.Console.ReadLine();
            device.Stop();
        }
    }
}
