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
    public class PacijentService : BaseService<Model.Pacijent, Database.Pacijent, PacijentSearchObject, PacijentInsertRequest, PacijentUpdateRequest>, PacijentInterface
    {
        public PacijentService(eKlinikaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<bool> DeleteById(int id)
        {
            try
            {
                var pacijent = await _context.Pacijenti.FindAsync(id);

                if (pacijent == null)
                {
                    return false; 
                }

           
                var prijemi = _context.PrijemPacijenta.Where(p => p.PacijentId == id);

          
                _context.PrijemPacijenta.RemoveRange(prijemi);

         
                _context.Pacijenti.Remove(pacijent);

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
