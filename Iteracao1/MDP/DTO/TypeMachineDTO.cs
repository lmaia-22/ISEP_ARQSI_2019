using System.Collections.Generic;
using System.Linq;
using ProjectIteration1.Models;

namespace ProjectIteration1.DTO
{
    public class TypeMachineDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public List<long> OperationsIds { get; set; }

        public TypeMachineDTO(){     }

        public TypeMachineDTO(TypeMachine typeMachine){
            this.Id = typeMachine.Id;
            this.Description = typeMachine.Description;
            this.OperationsIds = typeMachine.OperationsIds.Split(',').Select(long.Parse).ToList();
        }
    }
}