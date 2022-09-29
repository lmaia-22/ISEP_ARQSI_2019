namespace ProjectIteration1.Models
{
    public class Product {
        public long Id { get; set; }
        public long FabricPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
    }
}