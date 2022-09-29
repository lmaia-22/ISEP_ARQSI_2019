using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemTools
    {
        [Key]
        public long IdTools { get; set; }
        public string Description { get; set; }
    }
}