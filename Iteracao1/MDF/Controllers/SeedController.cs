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
            if (_context.Product.Count() != 0) {
                return NotFound();
            }
            
            createProducts();
            _context.SaveChanges();
            createFabricPlans();
            _context.SaveChanges();

            return Ok();
        }

       
         public void createProducts() {
            _context.Product.Add(new Product {
                Name = "Produto 1",
                FabricPlanId = (long) 1,
                Description = " descrição do prod 1",
                Price = 1,
                Active = true
            });
            _context.Product.Add(new Product {
                Name = "Produto 2",
                FabricPlanId = (long) 2,
                Description = " descrição do prod 2",
                Price = 2,
                Active = true
            });
            _context.Product.Add(new Product {
                Name = "Produto 3",
                FabricPlanId = (long) 3,
                Description = " descrição do prod 3",
                Price = 3,
                Active = true
            });
            _context.Product.Add(new Product {
                Name = "Produto 4",
                FabricPlanId = (long) 4,
                Description = " descrição do prod 4",
                Price = 4,
                Active = true
            });
            _context.Product.Add(new Product {
                Name = "Produto 5",
                FabricPlanId = (long) 5,
                Description = " descrição do prod 5",
                Price = 5,
                Active = true
            });
            _context.Product.Add(new Product {
                Name = "pl",
                FabricPlanId = (long) 5,
                Description = "Produto novo",
                Price = 100,
                Active = true
            });
            _context.Product.Add(new Product {
                Name = "product vw",
                FabricPlanId = (long) 4,
                Description = "rd",
                Price = 67,
                Active = true
            });
         }

         public void createFabricPlans() {
            _context.FabricPlan.Add(new FabricPlan {
                Description = "Descrição do plano 1",
                DateStart = new DateTime(2019, 10, 30),
                OperationsIds = "1, 2",
                Duration = 7
            });
            _context.FabricPlan.Add(new FabricPlan {
                Description = "Descrição do plano 2",
                DateStart = new DateTime(2019, 11, 30),
                OperationsIds = "1, 2",
                Duration = 4
            });
            _context.FabricPlan.Add(new FabricPlan {
                Description = "Descrição do plano 3",
                DateStart = new DateTime(2020, 01, 30),
                OperationsIds = "1, 2",
                Duration = 10
            });
            _context.FabricPlan.Add(new FabricPlan {
                Description = "Descrição do plano 4",
                DateStart = new DateTime(2020, 02, 27),
                OperationsIds = "1, 2",
                Duration = 2
            });
            _context.FabricPlan.Add(new FabricPlan {
                Description = "Descrição do plano 5",
                DateStart = new DateTime(2020, 03, 30),
                OperationsIds = "1, 2",
                Duration = 7
            });
         }
    }
}