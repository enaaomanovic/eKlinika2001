using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    [ApiController]


    public class PrijemPacijentaController : BaseController<Model.PrijemPacijenta, PrijemPacijentaSearchObject, PrijemPacijentaInsertRequest, PrijemPacijentaUpdateRequest>
    {
        public PrijemPacijentaController(ILogger<BaseController<PrijemPacijenta, PrijemPacijentaSearchObject, PrijemPacijentaInsertRequest, PrijemPacijentaUpdateRequest>> logger, PrijemPacijentaService service) : base(logger, service)
        {

        }
    }
}
