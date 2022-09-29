using System;

namespace ProjectIteration1.Models
{
    public class FabricPlan {
        public long Id { get; set; }
        public string Description { get; set; }
        public string OperationsIds { get; set; }
        public DateTime DateStart { get; set; }
        public long Duration { get; set; }
    }
}