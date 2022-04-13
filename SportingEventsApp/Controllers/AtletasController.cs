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
    public class AtletasController : Controller
    {
        private readonly IAtletaRepository _repository;
        public AtletasController(IAtletaRepository repository)
        {
            _repository = repository;
        }

        //GET: Atletas
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            return View(await _repository.GetBySearch(searchString));
        }

        // GET: Atletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var atleta = await _repository.GetById((int)id);
            if (atleta == null) return NotFound();

            return View(atleta);
        }

        // GET: Atletas/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EventoId"] = await _repository.GetEvents(null);
            return View();
        }

        // POST: Atletas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atleta atleta)
        {
            if (_repository.EntityExists(atleta.Id)) return BadRequest("Id do Atleta já existe.");

            _repository.Create(atleta);
            await _repository.SaveChangesAsync();
            ViewData["EventoId"] = await _repository.GetEvents(atleta.EventoId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Atletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null) return NotFound();

            var atleta = await _repository.GetById((int)id);
            if (atleta == null) return NotFound();
            ViewData["EventoId"] = await _repository.GetEvents(atleta.EventoId);

            return View(atleta);
        }

        // POST: Atletas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Atleta atleta)
        {
            if (id != atleta.Id) return NotFound();

            if (!_repository.EntityExists(atleta.Id)) return NotFound();
            _repository.Update(atleta);
            await _repository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Atletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var atleta = await _repository.GetById((int)id);
            if (atleta == null) return NotFound();

            return View(atleta);
        }

        // POST: Atletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atleta = await _repository.GetById(id);
            if (atleta == null) return NotFound();

            _repository.Delete(atleta);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }  
    }
}
