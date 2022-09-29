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
    public class OperationController : ControllerBase
    {
        private readonly ProjectContext _context;

        public OperationController(ProjectContext context)
        {
            _context = context;

            if (_context.Operation.Count() == 0)
            {
                new SeedController(context).GetAll();
            }
        }

        // =========== GET ==========
        [HttpGet]
        public IEnumerable<OperationDTO> GetAll()
        {
            return _context.Operation.Select(operation => new OperationDTO(operation)).ToList();
        }

        [HttpGet("{id}", Name = "GetOperation")]
        public ActionResult<OperationDTO> GetById([FromRoute] long id)
        {
            var item = _context.Operation.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found an Operation with the Id "+ id + "!");
            }

            return new OperationDTO(item);
        }

        // =========== POST ==========
        [HttpPost]
        public IActionResult CreateAsync(OperationDTO item)
        {
            if (!isOperationValidAsync(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Description is invalid or missing."); 
            }

            Operation operationToAdd = new Operation(){
                Description = item.Description
            };

            _context.Operation.Add(operationToAdd);
            _context.SaveChanges();

            return Ok(new OperationDTO(operationToAdd));
        }

        // =========== UPDATE ==========
        [HttpPut("{id}")]
        public IActionResult Update(long id, OperationDTO item)
        {
            var operation = _context.Operation.Find(id);
            if (operation == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found an Operation with the Id "+ id + "!");
            }

            operation.Description = item.Description;

            _context.Operation.Update(operation);
            _context.SaveChanges();

            return Ok(new OperationDTO(operation));
        }

        // =========== DELETE ==========
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var operation = _context.Operation.Find(id);
            if (operation == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found an Operation with the Id "+ id + "!");
            }

            _context.Operation.Remove(operation);
            _context.SaveChanges();
            return ResponseMessage.HttpResponse(
                201, 
                MessageType.DELETED, 
                "The Operation was sucessefully deleted.");
        }

        public bool isOperationValidAsync(OperationDTO operation) {
            if (string.IsNullOrWhiteSpace(operation.Description)) {
                return false;
            }
            return true;
        }
    }
}