using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectIteration1.Models;
using ProjectIteration1.DTO;
using System;

namespace ProjectIteration1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ProjectContext _context;

        public SeedController(ProjectContext context) {            
            _context = context;
        }

        // =========== GET ==========
        [HttpGet]
        public IActionResult GetAll()
        {
            if ((_context.ProductionLine.Count() != 0)) {
                return NotFound();
            }

            
            createTypeMachines();
            _context.SaveChanges();
            createMachines();
            _context.SaveChanges();
            createOperation();
            _context.SaveChanges();
            createProductionLine();
            _context.SaveChanges();
            return Ok();
        }


        public void createTypeMachines() {
            _context.TypeMachine.Add(new TypeMachine {
                Description = "Type Machine 1",
                OperationsIds = "1, 2"
            });
            _context.TypeMachine.Add(new TypeMachine {
                Description = "Type Machine 2",
                OperationsIds = "1, 2"
            });
            _context.TypeMachine.Add(new TypeMachine {
                Description = "Type Machine 3",
                OperationsIds = "1, 2"
            });
            _context.TypeMachine.Add(new TypeMachine {
                Description = "Type Machine 4",
                OperationsIds = "1, 2"
            });
            _context.TypeMachine.Add(new TypeMachine {
                Description = "Type Machine 5",
                OperationsIds = "1, 2"
            });
        }

        public void createMachines() {
            _context.Machine.Add(new Machine {
                IdTypeMachine = (long) 1,
                Brand = "Brand 1",
                Model = "Model 1",
                Localization = "Localization 1",
                Description = "Description of Machine 1",
                InspectionDate = new DateTime(2020,10,15),
                StatusOperational = true
            });
            _context.Machine.Add(new Machine {
                IdTypeMachine = (long) 2,
                Brand = "Brand 2",
                Model = "Model 2",
                Localization = "Localization 2",
                Description = "Description of Machine 2",
                InspectionDate = new DateTime(2020,10,16),
                StatusOperational = false
            });
            _context.Machine.Add(new Machine {
                IdTypeMachine = (long) 3,
                Brand = "Brand 3",
                Model = "Model 3",
                Localization = "Localization 3",
                Description = "Description of Machine 3",
                InspectionDate = new DateTime(2020,10,17),
                StatusOperational = true
            });
            _context.Machine.Add(new Machine {
                IdTypeMachine = (long) 4,
                Brand = "Brand 4",
                Model = "Model 4",
                Localization = "Localization 4",
                Description = "Description of Machine 4",
                InspectionDate = new DateTime(2020,10,18),
                StatusOperational = true
            });
            _context.Machine.Add(new Machine {
                IdTypeMachine = (long) 5,
                Brand = "Brand 5",
                Model = "Model 5",
                Localization = "Localization 5",
                Description = "Description of Machine 5",
                InspectionDate = new DateTime(2020,10,19),
                StatusOperational = true
            });
        }   

        public void createOperation() {
            _context.Operation.Add(new Operation {
                Description = "Operation 1"
            });
            _context.Operation.Add(new Operation { 
                Description = "Operation 2"
            });
            _context.Operation.Add(new Operation {
                Description = "Operation 3"
            });
            _context.Operation.Add(new Operation {
                Description = "Operation 4"
            });
            _context.Operation.Add(new Operation {
                Description = "Operation 5"
            });
         }

        public void createProductionLine() {
            _context.ProductionLine.Add(new ProductionLine(){
                Description = "Description 1 of Production Line",
                MachinesIds = "1, 2",
                ProductionLineNumber = 1,
                DateOperationStarted = new DateTime(2019,09,19),
                DateOperationFinished = new DateTime(2019,10,25),
                Active = true,
                DailyProductionCapacity = 500
            });
            _context.ProductionLine.Add(new ProductionLine(){
                Description = "Description 2 of Production Line",
                MachinesIds = "2, 4",
                ProductionLineNumber = 2,
                DateOperationStarted = new DateTime(2019,10,19),
                DateOperationFinished = new DateTime(2019,10,25),
                Active = false,
                DailyProductionCapacity = 500
            });
         }
    }
}