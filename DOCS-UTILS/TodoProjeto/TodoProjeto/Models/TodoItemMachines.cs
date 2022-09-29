using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemMachines
    {
        [Key]
        public long IdMachine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
        public DateTime InspectionDate { get; set; }
        public string StatusOperational { get; set; }

        //  [ForeignKey("IdMachineOperation")]

        //  public IdMachineOperation IdMachineOperation { get; set; }
    }
}