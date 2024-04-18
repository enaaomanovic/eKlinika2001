using AutoMapper;
using eKlinika.Services.Context;
using FitnessCentar.Model.SearchObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Base
{
    public class BaseService<T, TDb, TSearch, TInsert, TUpdate> :
        BaseInterface<T, TSearch, TInsert, TUpdate> where TDb : class where T : class where TSearch
        : BaseSearchObject where TInsert : class where TUpdate : class

    {
        protected eKlinikaContext _context;
        protected IMapper _mapper { get; set; }

        public BaseService(eKlinikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<List<T>> Get(TSearch? search = null)
        {
            var query = _context.Set<TDb>().AsQueryable();

            query = AddFilter(query, search);
            query = AddInclude(query);

            var list = await query.ToListAsync();

            return _mapper.Map<List<T>>(list);
        }

        public virtual async Task<T> GetById(int id)
        {

            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<T>(entity);
        }


        public virtual async Task<T> Insert(TInsert insert)
        {
            var set = _context.Set<TDb>();
            TDb entity = _mapper.Map<TDb>(insert);
            set.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> Update(int id, TUpdate update)
        {
            try
            {
                var set = _context.Set<TDb>();
                var entity = await set.FindAsync(id);
                _mapper.Map(update, entity);

                await _context.SaveChangesAsync();

                return _mapper.Map<T>(entity);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Greška prilikom čuvanja promena u bazi podataka: {ex.Message}");
                throw;
            }
        }
        public virtual async Task<bool> DeleteById(int id)
        {
            try
            {
                var set = _context.Set<TDb>();
                var entity = await set.FindAsync(id);

                if (entity != null)
                {
                    set.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true; // Uspješno obrisan entitet
                }
                else
                {
                    return false; // Entitet nije pronađen
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom brisanja entiteta iz baze podataka: {ex.Message}");
                throw;
            }
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query)
        {
            return query;
        }
        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }
    }
}
