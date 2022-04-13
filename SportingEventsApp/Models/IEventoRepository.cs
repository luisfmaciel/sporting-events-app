using System.Linq.Expressions;

namespace SportingEventsApp.Models
{
    public interface IEventoRepository
    {
        void Create(Evento item);
        void Delete(Evento item);
        bool EntityExists(int id);
        Task<IEnumerable<Evento>> GetAll();
        Task<IEnumerable<Evento>> GetByCondition(Expression<Func<Evento, bool>> expression);
        Task<IEnumerable<Evento>> GetBySearch(string stringSearch);
        Task<Evento> GetById(int id);
        void SaveChanges();
        Task SaveChangesAsync();
        void Update(Evento item);
    }
}