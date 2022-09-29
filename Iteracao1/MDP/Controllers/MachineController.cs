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
    public class MachineController : ControllerBase
    {
        private readonly ProjectContext _context;

        public MachineController(ProjectContext context)
        {
            _context = context;

            if (_context.Machine.Count() == 0)
            {
                new SeedController(context).GetAll();
            }
        }

        // =========== GET ==========
        [HttpGet]
        public IEnumerable<MachineDTO> GetAll()
        {
            return _context.Machine.Select(machine => new MachineDTO(machine)).ToList();
        }

        [HttpGet("{id}", Name = "GetMachine")]
        public ActionResult<MachineDTO> GetById([FromRoute] long id)
        {
            var item = _context.Machine.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Machine with the Id "+ id + "!");
            }

            return new MachineDTO(item);
        }

        // =========== POST ==========
        [HttpPost]
        public IActionResult Create(MachineDTO item)
        {
            if (!isMachineValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Any field is invalid or missing."); 
            }

            Machine machineToAdd = new Machine(){
                IdTypeMachine = item.IdTypeMachine,
                Brand = item.Brand,
                Model = item.Model,
                Localization = item.Localization,
                Description = item.Description,
                InspectionDate = item.InspectionDate,
                StatusOperational = item.StatusOperational
            };

            _context.Machine.Add(machineToAdd);
            _context.SaveChanges();

            return Ok(new MachineDTO(machineToAdd));
        }

        // =========== UPDATE ==========
        [HttpPut("{id}")]
        public IActionResult Update(long id, MachineDTO item)
        {
            var machine = _context.Machine.Find(id);
            if (machine == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Machine with the Id "+ id + "!");
            }

            if (!isMachineValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Any field is invalid or missing."); 
            }

            
            machine.IdTypeMachine = item.IdTypeMachine;
            machine.Brand = item.Brand;
            machine.Model = item.Model;
            machine.Localization = item.Localization;
            machine.Description = item.Description;
            machine.InspectionDate = item.InspectionDate;
            machine.StatusOperational = item.StatusOperational;

            _context.Machine.Update(machine);
            _context.SaveChanges();

            return Ok(new MachineDTO(machine));
        }

        // =========== DELETE ==========
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var machine = _context.Machine.Find(id);
            if (machine == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Machine with the Id "+ id + "!");
            }

            _context.Machine.Remove(machine);
            _context.SaveChanges();
            return ResponseMessage.HttpResponse(
                201, 
                MessageType.DELETED, 
                "The Machine was sucessefully deleted.");
        }

        public bool isMachineValid(MachineDTO machine) {
            bool isValid = true;
            TypeMachine typeMachine = _context.TypeMachine.Find(machine.IdTypeMachine);
            if (typeMachine == null) {
                isValid = false;
            }

            if(string.IsNullOrWhiteSpace(machine.Brand)) {
                isValid = false;
            }

            if(string.IsNullOrWhiteSpace(machine.Model)) {
                isValid = false;
            }

            if(string.IsNullOrWhiteSpace(machine.Localization)) {
                isValid = false;
            }

            if(string.IsNullOrWhiteSpace(machine.Description)) {
                isValid = false;
            }

            if(machine.InspectionDate.Equals("")) {
                isValid = false;
            }

            return isValid;
        }
    }
}