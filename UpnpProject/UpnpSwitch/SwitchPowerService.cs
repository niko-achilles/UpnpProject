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
    using System;

    public class SwitchPowerService : IUPnPService
    {
        
        private UPnPService _upnpService;
        
        private const string URN = "urn:schemas-upnp-org:service:SwitchPower:1";
        private const string ServiceID = "urn:upnp-org:serviceId:SwitchPower.0001";

        public SwitchPowerService()
        {
            this._upnpService = this.GetUPnPService();

            this._upnpService.GetStateVariableObject("Status")
                                .OnModified += new UPnPStateVariable.ModifiedHandler(OnModified_Status);

            this._upnpService.GetStateVariableObject("Target")
                                .OnModified += new UPnPStateVariable.ModifiedHandler(OnModified_Target);

        }

        private void OnModified_Target(UPnPStateVariable sender, object NewValue)
        {
            Console.WriteLine("Target Modified Handler");
            Console.WriteLine("Sender Name is: " + sender.Name);
            Console.WriteLine("New Value is " + NewValue);
        }

        private void OnModified_Status(UPnPStateVariable sender, object NewValue)
        {
            Console.WriteLine("Status Modified Handler");

            Console.WriteLine("Sender Name is: " + sender.Name);
            Console.WriteLine("New Value is " + NewValue);

        }

        //IUPnP Interface Method
        public UPnPService GetUPnPService()
        {
            UPnPStateVariable[] RetVal = new UPnPStateVariable[2];

            RetVal[0] = new UPnPModeratedStateVariable(VarName: "Status", VarType: typeof(System.Boolean), SendEvents: true);
            RetVal[0].AddAssociation(ActionName: "GetStatus", ArgumentName: "ResultStatus");

            RetVal[1] = new UPnPModeratedStateVariable("Target", typeof(System.Boolean), false);
            RetVal[1].AddAssociation("GetTarget", "newTargetValue");
            RetVal[1].AddAssociation("SetTarget", "newTargetValue");

            UPnPService service = new UPnPService(version: 1,
                                            serviceID: ServiceID,
                                            serviceType: URN,
                                            IsStandardService: true,
                                            Instance: this);

            for (int i = 0; i < RetVal.Length; ++i)
            {
                service.AddStateVariable(RetVal[i]);
            }

            service.AddMethod("GetStatus");
            service.AddMethod("GetTarget");
            service.AddMethod("SetTarget");
            return service;

        }
        public System.Boolean Evented_Status
        {
            get
            {
                return ((System.Boolean)_upnpService.GetStateVariable("Status"));
            }
            set
            {
                _upnpService.SetStateVariable("Status", value);
            }
        }
        public System.Boolean Target
        {
            get
            {
                return ((System.Boolean)this._upnpService.GetStateVariable("Target"));
            }
            set
            {
                this._upnpService.SetStateVariable("Target", value);
            }
        }

        public void GetStatus(out System.Boolean ResultStatus)
        {
            ResultStatus = this.Evented_Status;
            Console.WriteLine("GetStatus " + this.Evented_Status );
        }

        public void GetTarget(out System.Boolean newTargetValue)
        {
            newTargetValue = this.Target;
            Console.WriteLine("Get Target, " + this.Target);
        }

        public void SetTarget(System.Boolean newTargetValue)
        {
            this.Target = newTargetValue;
            Console.WriteLine("Set Target, " + this.Target);
        }


        public void RemoveStateVariable_Status()
        {
            _upnpService.RemoveStateVariable(_upnpService.GetStateVariableObject("Status"));
        }
        public void RemoveStateVariable_Target()
        {
            _upnpService.RemoveStateVariable(_upnpService.GetStateVariableObject("Target"));
        }
        public void RemoveAction_GetStatus()
        {
            _upnpService.RemoveMethod("GetStatus");
        }
        public void RemoveAction_GetTarget()
        {
            _upnpService.RemoveMethod("GetTarget");
        }
        public void RemoveAction_SetTarget()
        {
            _upnpService.RemoveMethod("SetTarget");
        }

        public System.Net.IPEndPoint GetCaller()
        {
            return (_upnpService.GetCaller());
        }
        public System.Net.IPEndPoint GetReceiver()
        {
            return (_upnpService.GetReceiver());
        }
    }
}
