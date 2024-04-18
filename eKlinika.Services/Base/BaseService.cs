using AutoMapper;
using FitnessCentar.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Base
{
    public class BaseService<T, TDb, TSearch, TInsert, TUpdate> :
        BaseInterface<T, TSearch, TInsert, TUpdate> where TDb : class where T : class where TSearch
        : BaseSearchObject where TInsert : class where TUpdate : class

    {
        protected IMapper _mapper { get; set; }

        public BaseService(  IMapper mapper)
        {
            //_context = context;
            _mapper = mapper;
        }
        public Task<List<T>> Get(TSearch sreach = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(TInsert insert)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(int id, TUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
