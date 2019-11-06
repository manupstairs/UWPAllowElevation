using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCFBackgroundProcess
{
    [ServiceContract]
    public interface ILocalService
    {

        [OperationContract]
        ServiceControllerStatus StartService(string name);

        [OperationContract]
        ServiceControllerStatus StopService(string name);

        [OperationContract]
        ServiceControllerStatus GetServiceStatus(string name);
    }
}
