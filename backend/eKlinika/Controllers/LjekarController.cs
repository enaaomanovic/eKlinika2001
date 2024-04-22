using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services;
using eKlinika.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    [ApiController]

    public class LjekarController : BaseController<Model.Ljekar, LjekarSearchObject, LjekarInsertRequest, LjekarUpdateRequest>
    {
        public LjekarController(ILogger<BaseController<Ljekar, LjekarSearchObject, LjekarInsertRequest, LjekarUpdateRequest>> logger, LjekarInterface service) : base(logger, service)
        {

        }
    }
}
