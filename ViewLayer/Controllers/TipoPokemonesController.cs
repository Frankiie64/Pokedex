using BusinessLayer.ModelView;
using BusinessLayer.Services;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewLayer.Controllers
{
    public class TipoPokemonesController : Controller
    {

        private readonly TiposPokemonService _service;
        public TipoPokemonesController(ApplicationDbContext db)
        {
            _service = new(db);
        }

        public async Task<IActionResult> Index()
        {
            var List = await _service.getAll();
            return View(List);
        }
        public IActionResult CreateTipoPokemon()
        {
            return View(new TiposPokemonesDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoPokemon(TiposPokemonesDto mv)
        {

            if(!ModelState.IsValid)
            {
                return View(mv);
            }

            bool value = await _service.add(mv);

            if (!value)
            {
                return View(mv);
            }

            return RedirectToRoute(new { Controller = "TipoPokemones", action = "Index" });

        }

        public async Task<IActionResult> EditipoPokemon(int id)
        {
            return View("CreateTipoPokemon", await _service.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditipoPokemon(TiposPokemonesDto mv)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateTipoPokemon", mv);
            }

           
           bool value = await _service.edit(mv);

            if (!value)
            {
                return View("CreateTipoPokemon", mv);
            }

            return RedirectToRoute(new { Controller = "TipoPokemones", action = "Index" });
        }
        public async Task<IActionResult> DeletetipoPokemon(int id)
        {
            return View(await _service.getById(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletetipoPokemonPost(int id)
        {

            bool value = await _service.delete(id);

            if (!value)
            {
                //deberia crear una vista para el error
            }
            return RedirectToRoute(new { Controller = "TipoPokemones", action = "Index" });
        }


        
    }
}
