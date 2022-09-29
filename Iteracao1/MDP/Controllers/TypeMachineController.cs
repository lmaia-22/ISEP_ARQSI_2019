using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProjectIteration1.Models;
using ProjectIteration1.DTO;
using ProjectIteration1.Utils;
using Microsoft.AspNetCore.Http;
using System.Web.Http.Cors;

namespace ProjectIteration1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")] 
    [Route("api/[controller]")]
    [ApiController]
    public class TypeMachineController : ControllerBase
    {
        private readonly ProjectContext _context;

        public TypeMachineController(ProjectContext context)
        {
            _context = context;

            if (_context.TypeMachine.Count() == 0)
            {
                new SeedController(context).GetAll();
            }
        }

        // =========== GET ==========
        [HttpGet]
        public IEnumerable<TypeMachineDTO> GetAll()
        {
            return _context.TypeMachine.Select(typeMachine => new TypeMachineDTO(typeMachine)).ToList();
        }

        [HttpGet("{id}", Name = "GetTypeMachine")]
        public ActionResult<TypeMachineDTO> GetById([FromRoute] long id)
        {
            var item = _context.TypeMachine.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Type of Machine with the Id "+ id + "!");
            }

            return new TypeMachineDTO(item);
        }

        [HttpGet("{id}/machines", Name = "GetMachinesByTypeMachines")]
        public ActionResult<List<long>> GetMachinesByTypeMachines([FromRoute] long id)
        {
            var item = _context.TypeMachine.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Type of Machine with the Id "+ id + "!");
            }

            List<long> machinesIds = new List<long>();

            foreach(Machine machine in _context.Machine) {

                if (machine.IdTypeMachine == id) {
                    machinesIds.Add(machine.Id);
                }
            }
            
            return machinesIds;
        }

        [HttpGet("{id}/operations", Name = "GetOperationsByTypeMachines")]
        public ActionResult<List<long>> GetOperationsByTypeMachines([FromRoute] long id)
        {
            var item = _context.TypeMachine.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Type of Machine with the Id "+ id + "!");
            }

            return item.OperationsIds.Split(',').Select(long.Parse).ToList();
        }


        // =========== POST ==========
        [HttpPost]
        public IActionResult Create(TypeMachineDTO item)
        {
            if (!isTypeMachineValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Description is invalid or missing."); 
            }

            TypeMachine typeMachineAdd = new TypeMachine(){
                Description = item.Description,
                OperationsIds = string.Join(",", item.OperationsIds)
            };

            _context.TypeMachine.Add(typeMachineAdd);
            _context.SaveChanges();

            return Ok(new TypeMachineDTO(typeMachineAdd));
        }

        // =========== UPDATE ==========
        [HttpPut("{id}")]
        public IActionResult Update(long id, TypeMachineDTO item)
        {
            var typeMachine = _context.TypeMachine.Find(id);
            if (typeMachine == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Type of Machine with the Id "+ id + "!");
            }

            if (!isTypeMachineValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Description is invalid or missing."); 
            }

            typeMachine.Description = item.Description;
            typeMachine.OperationsIds = string.Join(",", item.OperationsIds);

            _context.TypeMachine.Update(typeMachine);
            _context.SaveChanges();

            return Ok(new TypeMachineDTO(typeMachine));
        }

        // =========== DELETE ==========
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var typeMachine = _context.TypeMachine.Find(id);
            if (typeMachine == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Type of Machine with the Id "+ id + "!");
            }

            _context.TypeMachine.Remove(typeMachine);
            _context.SaveChanges();
            return ResponseMessage.HttpResponse(
                201, 
                MessageType.DELETED, 
                "The Type of Machine was sucessefully deleted.");
        }

        public bool isTypeMachineValid(TypeMachineDTO typeMachine) {

            //Check if all Operations Ids is available

            foreach (var operationId in typeMachine.OperationsIds)
            {
                Operation operationAux = _context.Operation.Find(operationId);
                if (operationAux == null) {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(typeMachine.Description)) {
                return false;
            }

            return true;
        }
    }
}