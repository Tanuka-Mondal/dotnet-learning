using Bicycle_Web_Tanuka.Context;
using Bicycle_Web_Tanuka.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bicycle_Web_Tanuka.Controllers
{
    public class BicycleController : Controller
    {
        private readonly BicycleDbContext context;
        public BicycleController(BicycleDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var bicycles = context.Bicycles.ToList();
            return View(bicycles);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BicycleDto bicycleDto)
        {
            if(!ModelState.IsValid)
            {
                return View(bicycleDto);
            }
            Bicycle bicycle = new Bicycle()
            {
                Name = bicycleDto.Name,
                Category = bicycleDto.Category,
                Price = bicycleDto.Price,
            };
            context.Bicycles.Add(bicycle);
            context.SaveChanges();
            return RedirectToAction("Index", "Bicycle");
        }

        public IActionResult Edit(int id)
        {
            var bicycle = context.Bicycles.Find(id);
            if (bicycle == null)
            {
                return RedirectToAction("Index", "Bicycle");
            }
            var bicycleDto = new BicycleDto()
            {
                Name = bicycle.Name,
                Category = bicycle.Category,
                Price = bicycle.Price,
            };
            ViewData["BicycleId"] = bicycle.Id;
            return View(bicycleDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, BicycleDto bicycleDto)
        {
            var bicycle = context.Bicycles.Find(id);
            if (bicycle == null)
            {
                return RedirectToAction("Index", "Bicycle");
            }
            if (!ModelState.IsValid)
            {
                ViewData["BicycleId"] = bicycle.Id;
                return View(bicycleDto);
            }
            bicycle.Name = bicycleDto.Name;
            bicycle.Category = bicycleDto.Category;
            bicycle.Price = bicycleDto.Price;
            context.SaveChanges();
            return RedirectToAction("Index", "Bicycle");
        }

        public IActionResult Delete(int id)
        {
            var bicycle = context.Bicycles.Find(id);
            if (bicycle == null)
            {
                return RedirectToAction("Index", "Bicycle");
            }
            context.Bicycles.Remove(bicycle);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Bicycle");
        }
    }
}
