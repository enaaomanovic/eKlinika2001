using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services.Base;
using eKlinika.Services.Context;
using eKlinika.Services.Database;
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
        public PrijemPacijentaService(eKlinikaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<PrijemPacijenta> AddFilter(IQueryable<PrijemPacijenta> query, PrijemPacijentaSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);


            if (search.DatumIVrijemePrijemaStart != null && search.DatumIVrijemePrijemaEnd != null)
            {
                filteredQuery = filteredQuery.Where(x => x.DatumIVrijemePrijema.Date >= search.DatumIVrijemePrijemaStart.Value.Date &&
                x.DatumIVrijemePrijema.Date <= search.DatumIVrijemePrijemaEnd.Value.Date);
            }

            return filteredQuery;
        }
        public override async Task<bool> DeleteById(int id)
        {
            try
            {
                var prijem = await _context.PrijemPacijenta.FindAsync(id);

                if (prijem == null)
                {
                    return false;
                }


                var nalazi = _context.Nalazi.Where(p => p.PrijemPacijentaId == id);


                _context.Nalazi.RemoveRange(nalazi);


                _context.PrijemPacijenta.Remove(prijem);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom brisanja pacijenta i prijema iz baze podataka: {ex.Message}");
                throw;
            }
        }

    }
}
