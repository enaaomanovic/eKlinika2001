﻿using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services;
using eKlinika.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    [ApiController]


    public class PacijentController : BaseController<Model.Pacijent, PacijentSearchObject, PacijentInsertRequest, PacijentUpdateRequest>
    {
        public PacijentController(ILogger<BaseController<Pacijent, PacijentSearchObject, PacijentInsertRequest, PacijentUpdateRequest>> logger, PacijentInterface service) : base(logger, service)
        {

        }
    }
}
