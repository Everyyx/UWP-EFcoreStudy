using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUWP.Data
{
    public interface IDataRepository<T>
    {
        Task Add(T Room);
        Task<ObservableCollection<T>> Load();
        Task Remove(T Room);
        Task UpDate(T Room);
    }
}
