using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemFabricPlan
    {
        [Key]
        public long IdFabricPlan { get; set; }
        public string Description { get; set; }
        public DateTime DataStart { get; set; }

          [ForeignKey("IdProduct")]

          public TodoItemProduct IdProduct { get; set; }
    }
}