// **************************************************************************** 
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.05.2016</date> 
// <project>UpnpConsoleClient</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

namespace UpnpConsoleClient
{
    using System;
    using UpnpDevice;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UPnP .NET Framework Console Client. Uses the Binary Light Device according to the upnp spec.");

            BinaryLight device = new BinaryLight();

            device.Start();

            Console.WriteLine("Press return to stop device.");
            Console.ReadLine();

            device.Stop();
        }
    }
}
