using BusinessLayer.Services;
using DataLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViewLayer.Models;
using BusinessLayer.ModelView;

namespace ViewLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _servicePokemon;

        public HomeController(ApplicationDbContext db)
        {
            _servicePokemon = new(db);
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomePokemonView()
            {
                Pokemon = await _servicePokemon.getAll(),
                Regiones = await _servicePokemon.getAllRegiones()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Index(HomePokemonView mv)
        {
            var list = _servicePokemon.GetPokemonesBySearch(mv.Region.Nombre);
            return View(new HomePokemonView()
            {
                Pokemon = await list,
                Regiones = await _servicePokemon.getAllRegiones()
            });
        }
        [HttpPost]
        public async Task<IActionResult> FindByRegion(HomePokemonView mv)
        {
            var list = _servicePokemon.GetPokemonesBySearch(mv.Region.IdRegion);
            return View("Index",new HomePokemonView()
            {
                Pokemon = await list,
                Regiones = await _servicePokemon.getAllRegiones()
            });
        }
        public async Task<ActionResult> MoreInfo(int id)
        {
            var item = await _servicePokemon.getById(id);

            return View(item);
        }
    }
}
