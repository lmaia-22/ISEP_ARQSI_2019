using System;
using ProjectIteration1.Models;

namespace ProjectIteration1.DTO
{
    public class MachineDTO
    {
        public long Id { get; set; }
        public long IdTypeMachine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool StatusOperational { get; set; }

        public MachineDTO(){     
        }

        public MachineDTO(Machine machine){
            this.Id = machine.Id;
            this.IdTypeMachine = machine.IdTypeMachine;
            this.Brand = machine.Brand;
            this.Model = machine.Model;
            this.Localization = machine.Localization;
            this.Description = machine.Description;
            this.InspectionDate = machine.InspectionDate;
            this.StatusOperational = machine.StatusOperational;
        }
    }
}