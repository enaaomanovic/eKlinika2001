using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    [ApiController]


    public class NalazController : BaseController<Model.Nalaz, NalazSearchObject, NalazInsertRequest, NalazUpdateRequest>
    {
        public NalazController(ILogger<BaseController<Nalaz, NalazSearchObject, NalazInsertRequest, NalazUpdateRequest>> logger, NalazService service) : base(logger, service)
        {

        }
    }
}
