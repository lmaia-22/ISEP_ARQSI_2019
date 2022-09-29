using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ProjectIteration1.Models;
using ProjectIteration1.Utils;
using ProjectIteration1.DTO;
using System;
using System.Web.Http.Cors;

namespace ProjectIteration1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")] 
    [Route("api/[controller]")]
    [ApiController]
    public class FabricPlanController : ControllerBase
    {
        private readonly ProjectContext _context;

        public FabricPlanController(ProjectContext context)
        {
            _context = context;

            if (_context.FabricPlan.Count() == 0)
            {
                new SeedController(context).GetAll();
            }
        }

        // =========== GET ==========
        [HttpGet]
        public IEnumerable<FabricPlanDTO> GetAll()
        {
            return _context.FabricPlan.Select(fabricPlan => new FabricPlanDTO(fabricPlan)).ToList();
        }

        [HttpGet("{id}", Name = "GetFabricPlan")]
        public ActionResult<FabricPlanDTO> GetById([FromRoute] long id)
        {
            var item = _context.FabricPlan.Find(id);
            if (item == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a FabricPlan with the Id "+ id + "!");
            }

            return new FabricPlanDTO(item);
        }

        // =========== POST ==========
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> Create(FabricPlanDTO item)
        {
            if (!await isFabricPlanValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Product or Date Start is invalid or missing."); 
            }

            FabricPlan fabricPlanToAdd = new FabricPlan(){
                Description = item.Description,
                OperationsIds = string.Join(",", item.OperationsIds),
                DateStart = item.DateStart,
                Duration = item.Duration
            };

            _context.FabricPlan.Add(fabricPlanToAdd);
            _context.SaveChanges();

            return Ok(new FabricPlanDTO(fabricPlanToAdd));
        }

        // =========== UPDATE ==========
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> Update(long id, FabricPlanDTO item)
        {
            var fabricPlan = _context.FabricPlan.Find(id);
            if (fabricPlan == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Fabric Plan with the Id "+ id + "!");
            }

            if (!await isFabricPlanValid(item)) {
                return ResponseMessage.HttpResponse(
                    411, 
                    MessageType.INVALID_DATA, 
                    "Any data is invalid or missing."); 
            }

            fabricPlan.Description = item.Description;
            fabricPlan.OperationsIds = string.Join(",", item.OperationsIds);
            fabricPlan.DateStart = item.DateStart;
            fabricPlan.Duration = item.Duration;

            _context.FabricPlan.Update(fabricPlan);
            _context.SaveChanges();

            return Ok(new FabricPlanDTO(fabricPlan));
        }

        // =========== DELETE ==========
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var fabricPlan = _context.FabricPlan.Find(id);
            if (fabricPlan == null)
            {
                return ResponseMessage.HttpResponse(
                    404, 
                    MessageType.NOT_FOUND, 
                    "Could not be found a Fabric Plan with the Id "+ id + "!");
            }

            _context.FabricPlan.Remove(fabricPlan);
            _context.SaveChanges();
            return ResponseMessage.HttpResponse(
                201, 
                MessageType.DELETED, 
                "The Fabric Plan was sucessefully deleted.");
        }


        public async System.Threading.Tasks.Task<bool> isFabricPlanValid(FabricPlanDTO fabricPlan) {

            if(fabricPlan.OperationsIds.Count > 0) {
                foreach(long operationId in fabricPlan.OperationsIds){
                    Operation operation = await HttpClientUtil.GetOperationRequestAsync("operation/"+ operationId);
                    if  (operation == null) {
                        return false;
                    }
                }
            }

            if(fabricPlan.DateStart == null) {
                return false; 
            }
            return true;
        }
    }
}