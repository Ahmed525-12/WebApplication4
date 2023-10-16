using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Empolyee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }

        public bool IsACtive { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}