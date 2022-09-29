using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ProjectIteration1.Models;
using ProjectIteration1.DTO;
using ProjectIteration1.Utils;
using System.Web.Http.Cors;

namespace ProjectIteration1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")] 
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLineController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProductionLineController(ProjectContext context)
        {
            _context = context;

            if (_context.ProductionLine.Count() == 0)
            {
                new SeedController(context).GetAll();
            }
        }

        // =========== GET ==========
        [HttpGet]
        public IEnumerable<ProductionLineDTO> GetAll()
        {
            return _context.ProductionLine.Select(productLine => new ProductionLineDTO(productLine)).ToList();
        }

        [HttpGet("{id}", Name = "GetProductionLine")]
        public ActionResult<ProductionLineDTO> GetById([FromRoute] long id)
        {
            var item = _context.ProductionLine.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Product Line with the Id "+ id + "!");
            }

            return new ProductionLineDTO(item);
        }

        // =========== POST ==========
        [HttpPost]
        public IActionResult Create(ProductionLineDTO item)
        {

            if (!isProductionLineValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Any field is invalid or missing."); 
            }

            ProductionLine productionLineAdd = new ProductionLine(){
                Description = item.Description,
                ProductionLineNumber = item.ProductionLineNumber,
                DateOperationStarted = item.DateOperationStarted,
                DateOperationFinished = item.DateOperationFinished,
                Active = item.Active,
                DailyProductionCapacity = item.DailyProductionCapacity,
                MachinesIds = string.Join(",", item.MachinesIds)
            };

            _context.ProductionLine.Add(productionLineAdd);
            _context.SaveChanges();

            return Ok(new ProductionLineDTO(productionLineAdd));
        }

        // =========== UPDATE ==========
        [HttpPut("{id}")]
        public IActionResult Update(long id, ProductionLineDTO item)
        {
            var productionLine = _context.ProductionLine.Find(id);
            if (productionLine == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Production Line with the Id "+ id + "!");
            }

            if (!isProductionLineValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Any field is invalid or missing."); 
            }

            productionLine.Description = item.Description;
            productionLine.ProductionLineNumber = item.ProductionLineNumber;
            productionLine.DateOperationStarted = item.DateOperationStarted;
            productionLine.DateOperationFinished = item.DateOperationFinished;
            productionLine.Active = item.Active;
            productionLine.DailyProductionCapacity = item.DailyProductionCapacity;
            productionLine.MachinesIds  = string.Join(",", item.MachinesIds);

            _context.ProductionLine.Update(productionLine);
            _context.SaveChanges();

            return Ok(new ProductionLineDTO(productionLine));
        }

        // =========== DELETE ==========
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var productionLine = _context.ProductionLine.Find(id);
            if (productionLine == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Production Line with the Id "+ id + "!");
            }

            _context.ProductionLine.Remove(productionLine);
            _context.SaveChanges();
            return ResponseMessage.HttpResponse(
                201, 
                MessageType.DELETED, 
                "The Production Line was sucessefully deleted.");
        }

        public bool isProductionLineValid(ProductionLineDTO productionLine) {

            //Check if all Machines Ids is available

            if(productionLine.MachinesIds != null && productionLine.MachinesIds.Count > 0) {
                foreach (var machineId in productionLine.MachinesIds)
                {
                    Machine machineAux = _context.Machine.Find(machineId);
                    if (machineAux == null) {
                        return false;
                    }
                }
            } else {
                return false;
            }


            
            if(string.IsNullOrWhiteSpace(productionLine.Description)) {
                return false;
            }

            if (productionLine.ProductionLineNumber < 1 || productionLine.DailyProductionCapacity < 1) {
                return false;
            }

            if (productionLine.DateOperationStarted.Equals("")){
                return false;
            }

            if (productionLine.DateOperationFinished.Equals("")){
                return false;
            }

            return true;
        }
    }
}