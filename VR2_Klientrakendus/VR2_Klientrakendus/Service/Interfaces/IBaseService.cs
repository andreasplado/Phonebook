using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VR2_Klientrakendus.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<ObservableCollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T data);
        Task<T> Update(T data, int id);
        Task<T> Delete(int id);
    }
}
