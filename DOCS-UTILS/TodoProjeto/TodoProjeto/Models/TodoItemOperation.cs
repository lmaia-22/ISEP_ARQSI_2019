using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemOperation
    {
        [Key]
        public long IdOperation { get; set; }
        public string Description { get; set; }

        //  [ForeignKey("IdFabricPlan")]

        //  public IdFabricPlan IdFabricPlan { get; set; }
    }
}