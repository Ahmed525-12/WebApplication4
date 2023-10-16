using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IGenricRepo<T>
    {
        Task<IEnumerable<T>> GetALL();

        Task<T> TGetByID(int ID);

        Task AddT(T T);

        void DeleteT(T T);

        void UpdateT(T T);
    }
}