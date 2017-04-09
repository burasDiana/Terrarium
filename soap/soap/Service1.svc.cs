using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        EntityModel db = new EntityModel();

        public List<TemperatureLog> GetAllData()
        {
            return db.TemperatureLog.ToList();
        }

        public void AddData(TemperatureLog data)
        {
            db.TemperatureLog.Add(new TemperatureLog()
            {
                Id = data.Id,
                Temperature = data.Temperature,
                Timestamp = data.Timestamp
            });
            db.SaveChanges();
        }

        public List<TemperatureLog> GetDataFrom(string fromTimestamp, string toTimestamp)
        {
            List<TemperatureLog> query = db.TemperatureLog.ToList();
            List<TemperatureLog> list = new List<TemperatureLog>();
            


            string format = "dd-MM-yyyy HH:mm:ss";
            var dateFrom = DateTime.ParseExact(fromTimestamp, format, null); //Converts from our own format, to VS standard format
            var dateTo = DateTime.ParseExact(toTimestamp, format, null); //Converts from our own format, to VS standard format

            list.AddRange(
                query.FindAll(s => DateTime.ParseExact(s.Timestamp, format, null) >= dateFrom 
                    && DateTime.ParseExact(s.Timestamp, format, null) <= dateTo)
                );
            return list;
        }

    }
}
