using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemProductionLine
    {
        [Key]
        public long IdProductionLine { get; set; }
        public string Description { get; set; }
        public long ProductionLineNumber { get; set; }
        public DateTime OperatedHours { get; set; }
        public Boolean Active { get; set; }
        public int DailyProductionCapacity { get; set; }

        //  [ForeignKey("IdMachine")]

        //  public IdMachine IdMachine { get; set; }
    }
}