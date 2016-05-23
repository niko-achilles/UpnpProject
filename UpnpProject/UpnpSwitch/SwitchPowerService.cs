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
        public UPnPService UPnPService  { get { return this._upnpService; } private set { this._upnpService = value; } }

        private const string URN = "urn:schemas-upnp-org:service:SwitchPower:1";

        public SwitchPowerService()
        {
            this.UPnPService = this.GetUPnPService();
            this.UPnPService.GetStateVariableObject("Status").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_Status);
            this.UPnPService.GetStateVariableObject("Target").OnModified += new UPnPStateVariable.ModifiedHandler(OnModifiedSink_Target);

        }

        private void OnModifiedSink_Target(UPnPStateVariable sender, object NewValue)
        {
            Console.WriteLine("Modified Target");
        }

        private void OnModifiedSink_Status(UPnPStateVariable sender, object NewValue)
        {
            Console.WriteLine("Modified Status");
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
                                            serviceID: "urn:upnp-org:serviceId:SwitchPower.0001",
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

        public void SetStateVariable(string VarName, object VarValue)
        {
            UPnPService.SetStateVariable(VarName, VarValue);
        }
        public object GetStateVariable(string VarName)
        {
            return (UPnPService.GetStateVariable(VarName));
        }

        public System.Boolean Evented_Status
        {
            get
            {
                return ((System.Boolean) this.UPnPService.GetStateVariable("Status"));
            }
            set
            {
                this.UPnPService.SetStateVariable("Status", value);
            }
        }
        public System.Boolean Target
        {
            get
            {
                return ((System.Boolean)this.UPnPService.GetStateVariable("Target"));
            }
            set
            {
                this.UPnPService.SetStateVariable("Target", value);
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
            UPnPService.RemoveStateVariable(UPnPService.GetStateVariableObject("Status"));
        }
        public void RemoveStateVariable_Target()
        {
            UPnPService.RemoveStateVariable(UPnPService.GetStateVariableObject("Target"));
        }
        public void RemoveAction_GetStatus()
        {
            UPnPService.RemoveMethod("GetStatus");
        }
        public void RemoveAction_GetTarget()
        {
            UPnPService.RemoveMethod("GetTarget");
        }
        public void RemoveAction_SetTarget()
        {
            UPnPService.RemoveMethod("SetTarget");
        }

        public System.Net.IPEndPoint GetCaller()
        {
            return (UPnPService.GetCaller());
        }
        public System.Net.IPEndPoint GetReceiver()
        {
            return (UPnPService.GetReceiver());
        }
    }
}
