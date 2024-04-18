using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Interface
{
    public interface PrijemPacijentaInterface : BaseInterface<PrijemPacijenta, PrijemPacijentaSearchObject, PrijemPacijentaInsertRequest, PrijemPacijentaUpdateRequest>
    {
    }
}
