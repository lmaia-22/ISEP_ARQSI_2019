using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TodoProjeto.Models
{
    public class TodoItemProduct
    {
        [Key]
        public long IdProduct { get; set; }
        public string Description { get; set; }
        public Boolean Active { get; set; }

    }
}