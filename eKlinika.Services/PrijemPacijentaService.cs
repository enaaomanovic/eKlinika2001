using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services.Base;
using eKlinika.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services
{
    public class PrijemPacijentaService : BaseService<Model.PrijemPacijenta, Database.PrijemPacijenta, PrijemPacijentaSearchObject, PrijemPacijentaInsertRequest, PrijemPacijentaUpdateRequest>, PrijemPacijentaInterface
    {
        public PrijemPacijentaService(IMapper mapper) : base(mapper)
        {
        }
    }
}
