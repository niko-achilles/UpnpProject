using OpenSource.UPnP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpnpSwitch
{
    public class SwitchPower
    {
        private  string FriendlyName = "Network Upnp Light Bulb";
        private  string Manufacturer = "Niko Kokkinos Factory";

        private  string ManufacturerURL = "http://nikolaoskokkinos.wordpress.com";

        private  string ModelName = "Network Light Bulb made for experiment";
        private  string ModelDescription = "Software Upnp Emulated Light Bulb";
        private  string ModelNumber = "12345";

        private  bool HasPresentation = false;
        private  string DeviceURN = "schemas-upnp-org:device:BinaryLight:0.9";

        private UPnPDevice device;

        public SwitchPower()
        {
            device = UPnPDevice.CreateRootDevice(1800, 1.0, "\\");

            device.FriendlyName = this.FriendlyName;

            device.Manufacturer = this.Manufacturer;

            device.ManufacturerURL = this.ManufacturerURL;

            device.ModelName = this.ModelName;

            device.ModelDescription = this.ModelDescription;

            device.ModelNumber = this.ModelNumber;

            device.HasPresentation = this.HasPresentation;

            device.DeviceURN = this.DeviceURN;

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
