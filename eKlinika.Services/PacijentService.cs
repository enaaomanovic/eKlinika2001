using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services.Base;
using eKlinika.Services.Context;
using eKlinika.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services
{
    public class PacijentService : BaseService<Model.Pacijent, Database.Pacijent, PacijentSearchObject, PacijentInsertRequest, PacijentUpdateRequest>, PacijentInterface
    {
        public PacijentService(eKlinikaContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
