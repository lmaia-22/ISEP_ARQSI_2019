using System;
using System.Collections.Generic;
using System.Linq;
using ProjectIteration1.Models;

namespace ProjectIteration1.DTO
{
    public class ProductionLineDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int ProductionLineNumber { get; set; }
        public DateTime DateOperationStarted { get; set; }
        public DateTime DateOperationFinished { get; set; }
        public bool Active { get; set; }
        public double DailyProductionCapacity { get; set; }  
        public List<long> MachinesIds { get; set; }

        public ProductionLineDTO(){     
        }

        public ProductionLineDTO(ProductionLine productionline){
            this.Id = productionline.Id;
            this.Description = productionline.Description;
            this.ProductionLineNumber = productionline.ProductionLineNumber;
            this.DateOperationStarted = productionline.DateOperationStarted;
            this.DateOperationFinished = productionline.DateOperationFinished;
            this.Active = productionline.Active;
            this.DailyProductionCapacity = productionline.DailyProductionCapacity;
            this.MachinesIds = productionline.MachinesIds.Split(',').Select(long.Parse).ToList();
        }
    }
}