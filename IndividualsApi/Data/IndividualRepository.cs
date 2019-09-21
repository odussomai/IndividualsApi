using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualsApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Individual[]> GetAllIndividualsAsync()
        {
            IQueryable<Individual> query = _context.Individuals;

            return await query.ToArrayAsync();
        }


        public async Task<Individual> GetIndividualAsync(int id)
        {
            IQueryable<Individual> query = _context.Individuals;


            // Query It
            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
