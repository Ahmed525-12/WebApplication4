using DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace WebApplication4.ViewModels
{
    public class EmployeeVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "name is requerd")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email  is requerd")]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public IFormFile Image { get; set; }
        public string ImageName { get; set; }

        public bool IsACtive { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}