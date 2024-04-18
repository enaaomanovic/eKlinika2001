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
    public class NalazService : BaseService<Model.Nalaz, Database.Nalaz, NalazSearchObject, NalazInsertRequest, NalazUpdateRequest>, NalazInterface
    {
        public NalazService(IMapper mapper) : base(mapper)
        {
        }
    }
}
