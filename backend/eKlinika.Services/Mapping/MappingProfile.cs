using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AutoMapper;

namespace eKlinika.Services.Mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Database.Pacijent, Model.Pacijent>();
            CreateMap<Model.Requests.PacijentInsertRequest, Database.Pacijent>();
            CreateMap<Model.Requests.PacijentUpdateRequest, Database.Pacijent>();


            CreateMap<Database.Ljekar, Model.Ljekar>();
            CreateMap<Model.Requests.LjekarInsertRequest, Database.Ljekar>();
            CreateMap<Model.Requests.LjekarUpdateRequest, Database.Ljekar>();


            CreateMap<Database.PrijemPacijenta, Model.PrijemPacijenta>();
            CreateMap<Model.Requests.PrijemPacijentaInsertRequest, Database.PrijemPacijenta>();
            CreateMap<Model.Requests.PrijemPacijentaUpdateRequest, Database.PrijemPacijenta>();


            CreateMap<Database.Nalaz, Model.Nalaz>();
            CreateMap<Model.Requests.NalazInsertRequest, Database.Nalaz>();
            CreateMap<Model.Requests.NalazUpdateRequest, Database.Nalaz>();
        }

        }
}
