using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ProjectIteration1.Models;
using ProjectIteration1.Utils;
using ProjectIteration1.DTO;
using System.Web.Http.Cors;

namespace ProjectIteration1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")] 
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProductController(ProjectContext context)
        {
            _context = context;

            if (_context.Product.Count() == 0)
            {
                new SeedController(context).GetAll();
                _context.SaveChanges();
            }
        }

        // =========== GET ==========
        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()
        {
            return _context.Product.Select(product => new ProductDTO(product)).ToList();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<ProductDTO> GetById([FromRoute] long id)
        {
            var item = _context.Product.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Product with the Id "+ id + "!");
            }

            return new ProductDTO(item);
        }

        // =========== POST ==========
        [HttpPost]
        public IActionResult Create(ProductDTO item)
        {
            if (!isProductValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Data is invalid or missing."); 
            }

            Product productToAdd = new Product(){
                FabricPlanId = item.FabricPlanId,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Active = item.Active
            };

            _context.Product.Add(productToAdd);
            _context.SaveChanges();

            return Ok(new ProductDTO(productToAdd));
        }

        // =========== UPDATE ==========
        [HttpPut("{id}")]
        public IActionResult Update(long id, ProductDTO item)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Product with the Id "+ id + "!");
            }

            if (!isProductValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Data is invalid or missing."); 
            }

            product.FabricPlanId = item.FabricPlanId;
            product.Name = item.Name;
            product.Description = item.Description;
            product.Price = item.Price;
            product.Active = item.Active;

            _context.Product.Update(product);
            _context.SaveChanges();

            return Ok(new ProductDTO(product));
        }

        // =========== DELETE ==========
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a product with the Id "+ id + "!");
            }

            _context.Product.Remove(product);
            _context.SaveChanges();
            return ResponseMessage.HttpResponse(
                201, 
                MessageType.DELETED, 
                "The product was sucessefully deleted.");
        }

        public bool isProductValid(ProductDTO product) {
            //TODO - CHECK FABRICPLAN and NAME

             FabricPlan fabricPlanAux = _context.FabricPlan.Find(product.FabricPlanId);
            if (fabricPlanAux == null) {
                return false;
            }

            if(string.IsNullOrWhiteSpace(product.Name)) {
                return false;
            }

            return true;
        }
    }
}