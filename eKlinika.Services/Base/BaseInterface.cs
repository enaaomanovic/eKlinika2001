using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Base
{
    public interface BaseInterface<T, TSearch, TInsert, TUpdate> where TSearch : class where TInsert : class where TUpdate : class where T : class
    {
        Task<List<T>> Get(TSearch sreach = null);
        Task<T> GetById(int id);
        Task<T> Insert(TInsert insert);
        Task<T> Update(int id, TUpdate update);

    }
}
