using Microsoft.EntityFrameworkCore;
using SportingEventsApp.Models;
using System.Linq.Expressions;

namespace SportingEventsApp.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EFContext _context;

        public EventoRepository(EFContext context)
        {
            _context = context;
        }

        public bool EntityExists(int id)
        {
            return _context.Set<Evento>().Any(p => p.Id == id);
        }
        public async Task<Evento?> GetById(int id)
        {
            return await _context.Set<Evento>()
                .Include(b => b.Atletas)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Evento>> GetBySearch(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return await _context.Set<Evento>()
                .Where(a => a.Modalidade.Contains(searchString))
                .ToListAsync();
            }

            return await _context.Set<Evento>()
            .OrderByDescending(a => a.Data)
            .ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetAll()
        {
            return await _context.Set<Evento>()
                .AsNoTracking()
                .Include(b => b.Atletas)
                .OrderByDescending(p => p.Data)
                .ToListAsync();
        }
        public async Task<IEnumerable<Evento>> GetByCondition(Expression<Func<Evento, bool>> expression)
        {
            return await _context.Set<Evento>().Where(expression)
                .Include(b => b.Atletas)
                .OrderByDescending(p => p.Modalidade)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Create(Evento item)
        {
            _context.Set<Evento>().Add(item);
        }

        public void Update(Evento item)
        {
            _context.Set<Evento>().Update(item);
        }

        public void Delete(Evento item)
        {
            _context.Set<Evento>().Remove(item);
        }
    }
}
