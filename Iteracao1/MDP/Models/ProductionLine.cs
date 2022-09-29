using System;
using System.Collections.Generic;

namespace ProjectIteration1.Models
{
    public class ProductionLine 
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int ProductionLineNumber { get; set; }
        public DateTime DateOperationStarted { get; set; }
        public DateTime DateOperationFinished { get; set; }
        public bool Active { get; set; }
        public double DailyProductionCapacity { get; set; }  
        public string MachinesIds { get; set; }
    }
}