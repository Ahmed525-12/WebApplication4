using BLL.interfaces;
using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.repostiries
{
    public class EmployeeRepo : GenricRepo<Empolyee>, EmployeeIC
    {
        private readonly CompanyMVC companyMVC;

        public EmployeeRepo(CompanyMVC companyMVC) : base(companyMVC)
        {
            this.companyMVC = companyMVC;
        }

        public IQueryable<Empolyee> getitemByName(string searchValue)
        {
            return companyMVC.Empolyee.Include(E => E.Department).Where(E => E.Name.ToLower().Contains(searchValue.ToLower()));
        }
    }
}