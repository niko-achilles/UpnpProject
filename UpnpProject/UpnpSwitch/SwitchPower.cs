// **************************************************************************** 
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.05.2016</date> 
// <project>UpnpSwitch</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

namespace UpnpSwitch
{
    using OpenSource.UPnP;

    public class SwitchPower
    {
        private  const string FriendlyName = "Network Upnp Light Bulb";
        private  const string Manufacturer = "Niko Kokkinos Factory";

        private const string ManufacturerURL = "http://nikolaoskokkinos.wordpress.com";

        private  const string ModelName = "Network Light Bulb made for experiment";
        private  const string ModelDescription = "Software Upnp Emulated Light Bulb";
        private  const string ModelNumber = "12345";

        private  const bool HasPresentation = false;
        private  const string DeviceURN = "schemas-upnp-org:device:BinaryLight:0.9";

        private UPnPDevice device;

        public SwitchPower()
        {
            device = UPnPDevice.CreateRootDevice(1800, 1.0, "\\");

            device.FriendlyName = FriendlyName;

            device.Manufacturer = Manufacturer;

            device.ManufacturerURL = ManufacturerURL;

            device.ModelName = ModelName;

            device.ModelDescription = ModelDescription;

            device.ModelNumber = ModelNumber;

            device.HasPresentation = HasPresentation;

            device.DeviceURN = DeviceURN;

            SwitchPowerService service = new SwitchPowerService ();
           
            device.AddService(service);

        }


        public void Start()
        {
            device.StartDevice();
        }

        public void Stop()
        {
            device.StopDevice();
        }
    }
}
