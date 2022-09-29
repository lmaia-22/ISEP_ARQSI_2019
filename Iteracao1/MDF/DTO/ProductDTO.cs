using ProjectIteration1.Models;

namespace ProjectIteration1.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public long FabricPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        public ProductDTO(){ }

        public ProductDTO(Product product){
            this.Id = product.Id;
            this.FabricPlanId = product.FabricPlanId;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price; 
            this.Active = product.Active;
        }
    }
}