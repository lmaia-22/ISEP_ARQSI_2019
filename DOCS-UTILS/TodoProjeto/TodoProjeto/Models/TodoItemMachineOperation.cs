using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemMachineOperation
    {
        [Key]
        public long IdMachineOperation { get; set; }
        public string DurationOperation { get; set; }

          [ForeignKey("IdOperation")]

         public TodoItemOperation IdOperation { get; set; }

            [ForeignKey("IdTypeMachine")]

        public TodoItemTypeMachine IdTypeMachine { get; set; }

          [ForeignKey("IdTools")]

          public TodoItemTools IdTools { get; set; }
    }
}