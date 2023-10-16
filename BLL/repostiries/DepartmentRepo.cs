using BLL.interfaces;
using DAL.Contexts;
using DAL.Models;

namespace BLL.repostiries
{
    public class DepartmentRepo : GenricRepo<Department>, DepartmentIC
    {
        private readonly CompanyMVC _companyMVC;

        public DepartmentRepo(CompanyMVC companyMVC) : base(companyMVC)
        {
        }
    }
}