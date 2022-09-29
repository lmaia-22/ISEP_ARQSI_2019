using ProjectIteration1.Models;

namespace ProjectIteration1.DTO
{
    public class OperationDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        
        public OperationDTO() {     }

        public OperationDTO(Operation operation){
            this.Id = operation.Id;
            this.Description = operation.Description;
        }
    }
}