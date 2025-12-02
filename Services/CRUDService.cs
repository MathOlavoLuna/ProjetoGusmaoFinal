using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Data;

namespace ProjetoGusmaoFinal.Services
{
    public class CRUDService<T>(DataContext Context) where T : class
    {
        private readonly DataContext _context = Context;

        [HttpGet]
        public async Task<T> Get(int Id) { 
            return await _context.Set<T>().FindAsync(Id);
        }

        [HttpGet]
        public async Task<List<T>>  GetAll() { 
            return await _context.Set<T>().ToListAsync();
        }
        [HttpPost]
        public async Task<T> Post(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        [HttpPut]

        public async Task<T> Put(T Entity)
        {
            _context.Set<T>().Update(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        [HttpDelete]
        public async Task<T> Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
