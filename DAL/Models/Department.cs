using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "name is requerd")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code  is requerd")]
        public string Code { get; set; }

        public DateTime DateOfCreation { get; set; }

        [InverseProperty("Department")]
        public ICollection<Empolyee> Empolyees { get; set; }
    }
}