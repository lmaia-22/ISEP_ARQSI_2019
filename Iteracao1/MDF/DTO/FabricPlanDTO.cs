using System;
using System.Collections.Generic;
using System.Linq;
using ProjectIteration1.Models;

namespace ProjectIteration1.DTO
{
    public class FabricPlanDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public List<long> OperationsIds { get; set; }
        public DateTime DateStart { get; set; }
        public long Duration { get; set; }

        public FabricPlanDTO(){ }

        public FabricPlanDTO(FabricPlan fabricPlan){
            this.Id = fabricPlan.Id;
            this.Description = fabricPlan.Description;
            this.OperationsIds = fabricPlan.OperationsIds.Split(',').Select(long.Parse).ToList();
            this.DateStart = fabricPlan.DateStart;
            this.Duration = fabricPlan.Duration;
        }
    }
}