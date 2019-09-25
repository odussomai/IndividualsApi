using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualsApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace IndividualsApi.Data
{
    public class IndividualRepository : IIndividualsRepository
    {
        private readonly IndividualsContext _context;

        public IndividualRepository(IndividualsContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Individual>> GetAllIndividualsAsync(int pageIndex, int pageSize)
        {
            IQueryable<Individual> query = _context.Individuals
                .Include(a => a.Relatives).ThenInclude(c => c.Relative)
                .Include(i => i.City)
                .Include(p => p.PhoneNumbers);
            

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        public async Task<Individual> GetIndividualAsync(int id)
        {
            IQueryable<Individual> query = _context.Individuals
                .Include(i => i.City)
                .Include(a => a.Relatives).ThenInclude(c => c.Relative)
                .Include(p => p.PhoneNumbers);

            // Query It
            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<T>> FindPaged<T>(int page, int pageSize) where T : class
        {
            return await _context.Set<T>().ToPagedListAsync(page, pageSize);
        }

        public async Task<Individual[]> Search(string term)
        {
            var result = _context.Individuals
                .Include(c => c.City)
                .Include(a => a.PhoneNumbers)
                .Where(i => i.FirstName.Contains(term) ||
                                                         i.LastName.Contains(term) ||
                                                         i.PersonalId.Contains(term) ||
                                                         (i.City != null && i.City.Name.Contains(term)) ||
                                                         i.PhoneNumbers.Any(p => p.PhoneNumber.Contains(term)));
            return await result.ToArrayAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            IQueryable<City> query = _context.Cities;

            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> GetRelationCountAsync(int id, RelationType type)
        {
            IQueryable<Relation> query = _context.Relations;

            return await query.CountAsync(r => r.IndividualId == id && r.Type == type);

            //return await query.CountAsync();
        }

        public async Task<Relation> GetRelationByRelativeId(int id, int relativeId, int relType)
        {
            IQueryable<Relation> query = _context.Relations;

            var type = (RelationType) relType;

            query.Where(r => r.IndividualId == id && r.RelativeId == relativeId && r.Type == type);

            return await query.FirstOrDefaultAsync();
        }
    }
}
