using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportingEventsApp.Models;

namespace SportingEventsApp.Models
{
    public interface IAtletaRepository
    {
        void Create(Atleta item);
        void Delete(Atleta item);
        bool EntityExists(int id);
        Task<IEnumerable<Atleta>> GetAll();
        Task<Atleta?> GetById(int? id);
        Task<IEnumerable<Atleta>> GetBySearch(string searchString);
        void SaveChanges();
        Task SaveChangesAsync();
        Task<SelectList> GetEvents(int? id);
        void Update(Atleta item);
    }
}