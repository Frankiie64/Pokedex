using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Model;
using BusinessLayer.Services;
using DataLayer.Data;
using BusinessLayer.ModelView;

namespace ViewLayer.Controllers
{
    public class RegionesController : Controller
    {
        private readonly RegionService _service;
        public RegionesController(ApplicationDbContext db)
        {
            _service = new(db);
        }

        public async Task<IActionResult> Index()
        {
            var List = await _service.getAll();
            return View(List);
        }

        public IActionResult CreateRegiones()
        {
            return View(new RegionesDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegiones(RegionesDto mv)
        {
            if (!ModelState.IsValid)
            {
                return View(mv);
            }

            bool value = await _service.add(mv);

            if (!value)
            {
                return View(mv);
            }

            return RedirectToRoute(new { Controller = "Regiones", action = "Index" });

        }
        public async Task<IActionResult> EditRegion(int id)
        {
            return View("CreateRegiones", await _service.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditRegion(RegionesDto mv)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateRegiones", mv);
            }

            bool value = await _service.edit(mv);

            if (!value)
            {
                return View("CreateRegiones", mv);
            }

            return RedirectToRoute(new { Controller = "Regiones", action = "Index" });
            
        }
        public async Task<IActionResult> DeleteRegion(int id)
        {
            return View(await _service.getById(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRegionPost(int id)
        {

            bool value = await _service.delete(id);

            if (!value)
            {
                //deberia crear una vista para el error
            }
            return RedirectToRoute(new { Controller = "Regiones", action = "Index" });
        }
    }
}
