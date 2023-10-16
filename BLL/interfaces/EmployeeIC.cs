using DAL.Models;
using System.Linq;

namespace BLL.interfaces
{
    public interface EmployeeIC : IGenricRepo<Empolyee>
    {
        IQueryable<Empolyee> getitemByName(string searchValue);
    }
}