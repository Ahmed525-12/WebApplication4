using BLL.interfaces;
using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.repostiries
{
    public class GenricRepo<T> : IGenricRepo<T> where T : class
    {
        private readonly CompanyMVC _companyMVC;

        public GenricRepo(CompanyMVC companyMVC)
        {
            _companyMVC = companyMVC;
        }

        public async Task AddT(T T)
        {
            await _companyMVC.AddAsync(T);
        }

        public void DeleteT(T T)
        {
            _companyMVC.Remove(T);
        }

        public async Task<IEnumerable<T>> GetALL()
        {
            if (typeof(T) == typeof(Empolyee))
            {
                return (IEnumerable<T>)await _companyMVC.Empolyee.Include(E => E.Department).ToListAsync();
            }
            return await _companyMVC.Set<T>().ToListAsync();
        }

        public async Task<T> TGetByID(int ID)
        {
            return await _companyMVC.Set<T>().FindAsync(ID);
        }

        public void UpdateT(T T)
        {
            _companyMVC.Update(T);
        }
    }
}