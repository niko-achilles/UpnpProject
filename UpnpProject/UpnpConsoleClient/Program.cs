// **************************************************************************** 
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.05.2016</date> 
// <project>UpnpConsoleClient</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

namespace UpnpConsoleClient
{
    using UpnpSwitch;

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
