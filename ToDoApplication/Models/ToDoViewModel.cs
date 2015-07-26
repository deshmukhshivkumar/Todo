using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class ToDoViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(1,5)]
        public int Priority { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime  CreatedOn  { get; set; }
    }
}