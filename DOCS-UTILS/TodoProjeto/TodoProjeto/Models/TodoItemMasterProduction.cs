using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemMasterProduction
    {
        [Key]
        public long IdMasterProduction { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }

            //  [ForeignKey("IdProductionLine")]

        //  public IdProductionLine IdProductionLine { get; set; }

            //  [ForeignKey("IdMachine")]

        //  public IdMachine IdMachine { get; set; }

            //  [ForeignKey("IdMachineOperation")]

        //  public IdMachineOperation IdMachineOperation { get; set; }

        
            //  [ForeignKey("IdOperation")]

        //  public IdOperation IdOperation { get; set; }

        
            //  [ForeignKey("IdFabricPlan")]

        //  public IdFabricPlan IdFabricPlan { get; set; }

        
            //  [ForeignKey("IdProduct")]

        //  public IdProduct IdProduct { get; set; }
    }
}