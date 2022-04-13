#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportingEventsApp.Models;

namespace SportingEventsApp.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoRepository _repository;
        public EventosController(IEventoRepository repository)
        {
            _repository = repository;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {

            return View(await _repository.GetBySearch(searchString));

        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var evento = await _repository.GetById((int)id);
            if (evento == null) return NotFound();

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evento evento)
        {
            if (_repository.EntityExists(evento.Id)) return BadRequest("Id do Evento já existe.");
            _repository.Create(evento);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var evento = await _repository.GetById((int)id);
            if (evento == null) return NotFound();

            return View(evento);
        }

        // POST: Eventoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Evento evento)
        {
            if (id != evento.Id) return NotFound();
            
            if (!_repository.EntityExists(evento.Id)) return NotFound();
            _repository.Update(evento);
            await _repository.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var evento = await _repository.GetById((int)id);
            if (evento == null) return NotFound();

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _repository.GetById(id);
            if (evento == null) return NotFound();

            _repository.Delete(evento);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
