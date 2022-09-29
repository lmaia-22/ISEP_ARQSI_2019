using System;

namespace ProjectIteration1.Models
{
    public class Machine 
    {
        public long Id { get; set; }
        public long IdTypeMachine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool StatusOperational { get; set; }
    }
}