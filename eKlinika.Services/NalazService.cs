using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services.Base;
using eKlinika.Services.Context;
using eKlinika.Services.Database;
using eKlinika.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services
{
    public class NalazService : BaseService<Model.Nalaz, Database.Nalaz, NalazSearchObject, NalazInsertRequest, NalazUpdateRequest>, NalazInterface
    {
        public NalazService(eKlinikaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Nalaz> AddFilter(IQueryable<Nalaz> query, NalazSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);


            if (search.PrijemPacijentaId != null )
            {
                filteredQuery = filteredQuery.Where(x => x.PrijemPacijentaId == search.PrijemPacijentaId);
            }

            return filteredQuery;
        }
    }
}
