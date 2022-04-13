using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportingEventsApp.Models;

namespace SportingEventsApp.Repositories
{
    public class AtletaRepository : IAtletaRepository
    {
        private readonly EFContext _context;

        public AtletaRepository(EFContext context)
        {
            _context = context;
        }

        public bool EntityExists(int id)
        {
            return _context.Set<Atleta>().Any(a => a.Id == id);
        }

        public async Task<Atleta?> GetById(int? id)
        {
            return await _context.Set<Atleta>()
               .Include(p => p.Evento)
               .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Atleta>> GetAll()
        {
            return await _context.Set<Atleta>()
                .AsNoTracking()
                .OrderByDescending(a => a.DataConfirmacao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Atleta>> GetBySearch(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return await _context.Set<Atleta>()
                .Where(a => a.Nome.Contains(searchString))
                .ToListAsync();
            }

            return await _context.Set<Atleta>()
            .OrderByDescending(a => a.DataConfirmacao)
            .ToListAsync();
        }

        public async Task<SelectList> GetEvents(int? id)
        {
            var eventos = await _context.Set<Evento>()
                .AsNoTracking()
                .ToListAsync();

            return new SelectList(eventos, "Id", "Titulo", id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Create(Atleta item)
        {
            _context.Set<Atleta>().Add(item);
        }

        public void Update(Atleta item)
        {
            _context.Set<Atleta>().Update(item);
        }

        public void Delete(Atleta item)
        {
            _context.Set<Atleta>().Remove(item);
        }
    }
}
