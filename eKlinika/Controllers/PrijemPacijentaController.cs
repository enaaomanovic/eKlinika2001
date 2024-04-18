using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services;
using eKlinika.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    [ApiController]


    public class PrijemPacijentaController : BaseController<Model.PrijemPacijenta, PrijemPacijentaSearchObject, PrijemPacijentaInsertRequest, PrijemPacijentaUpdateRequest>
    {
        public PrijemPacijentaController(ILogger<BaseController<PrijemPacijenta, PrijemPacijentaSearchObject, PrijemPacijentaInsertRequest, PrijemPacijentaUpdateRequest>> logger, PrijemPacijentaInterface service) : base(logger, service)
        {

        }
    }
}
