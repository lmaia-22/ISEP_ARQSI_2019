using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemTypeMachine
    {
        [Key]
        public long IdTypeMachine { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}