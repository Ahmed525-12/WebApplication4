using BLL.repostiries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IUnitOfWork
    {
        public EmployeeRepo employeeRepo { get; set; }
        public DepartmentRepo departmentRepo { get; set; }

        Task<int> complete();
    }
}