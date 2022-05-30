using BusinessLayer.ModelView;
using BusinessLayer.Services;
using DataLayer.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewLayer.Controllers
{
    public class PokemonesController : Controller
    {
        private readonly PokemonService _service;
        public PokemonesController(ApplicationDbContext db)
        {
            _service = new(db);
        }
        public async Task<IActionResult> Index()
        {
            var List = await _service.getAll();
            return View(List);
        }
       
        public async Task<IActionResult> CreatePokemon()
        {
            CreatePokemonDto mv = new()
            {
                Pokemon = new PokemonesDto(),
                Regiones = await _service.getAllRegiones(),
                Tipos = await _service.getAllTiposPokemones()
            };
            return View(mv);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemon(CreatePokemonDto mv)
        {
            CreatePokemonDto vm = new()
            {
                Pokemon = mv.Pokemon,
                Regiones = await _service.getAllRegiones(),
                Tipos = await _service.getAllTiposPokemones()
            };

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            bool value = await _service.add(mv.Pokemon);

            if (!value)
            {
                return View(mv);
            }

            return RedirectToRoute(new { Controller = "Pokemones", action = "Index" });

        }

        public async Task<IActionResult> EditPokemon(int id)
        {
            return View("CreatePokemon", new CreatePokemonDto()
            {
                Pokemon = await _service.getById(id),
                Regiones = await _service.getAllRegiones(),
                Tipos = await _service.getAllTiposPokemones()
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditPokemon(CreatePokemonDto mv)
        {

            if (!ModelState.IsValid)
            {
                return View("TipoPokemones", mv);
            }
          
            if (!await _service.edit(mv.Pokemon))
            {
                return View("CreatePokemones", mv);
            }

            return RedirectToRoute(new { Controller = "Pokemones", action = "Index" });
        }
        public async Task<IActionResult> DeletePokemon(int id)
        {
            return View(await _service.getById(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePokemonPost(int id)
        {

            bool value = await _service.delete(id);

            if (!value)
            {
                //deberia crear una vista para el error
            }
            return RedirectToRoute(new { Controller = "Pokemones", action = "Index" });
        }
    }
}
