using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<TemperatureLog> GetAllData();

        [OperationContract]
        void AddData(TemperatureLog data);

        [OperationContract]
        List<TemperatureLog> GetDataFrom(string fromTimestamp, string toTimestamp);
    }
}
