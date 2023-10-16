using BLL.interfaces;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.repostiries
{
    public class Unitofwork : IUnitOfWork
    {
        private readonly CompanyMVC companyMVC;

        public Unitofwork(CompanyMVC companyMVC)
        {
            employeeRepo = new EmployeeRepo(companyMVC);
            departmentRepo = new DepartmentRepo(companyMVC);
            this.companyMVC = companyMVC;
        }

        public EmployeeRepo employeeRepo { get; set; }
        public DepartmentRepo departmentRepo { get; set; }

        public async Task<int> complete()
        {
            return await companyMVC.SaveChangesAsync();
        }
    }
}