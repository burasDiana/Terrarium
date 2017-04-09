namespace soap
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TemperatureLog")]
    public partial class TemperatureLog
    {
        public TemperatureLog(string timestamp, double temperature)
        {
            Timestamp = timestamp;
            Temperature = temperature;
        }

        public TemperatureLog()
        {
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Timestamp { get; set; }

        public double Temperature { get; set; }
    }
}
