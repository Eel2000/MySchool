using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Data;
using MySchool.Models;

namespace MySchool.Controllers
{
    public class EleveController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EleveController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var ListElves = await _dbContext.Enfants
                .Include(e => e.Option)
                    .OrderBy(e => e.Grade)
                        .ThenByDescending(e => e.Grade)
                .OrderBy(e => e.LastName)
                    .ThenByDescending(e => e.LastName)
                .ToListAsync();

            return View(ListElves);
        }

        [HttpGet,ActionName("Search")]
        public async Task<IActionResult> Search( string key)
        {
            ViewData["Keyword"] = key;


            var etud = from e in _dbContext.Enfants
                       select e;

            if (!String.IsNullOrWhiteSpace(key))
            {
                etud = etud.Where(e => e.LastName.Contains(key)
                        || e.FirstName.Contains(key));

                
                return RedirectToAction("Index",await etud.AsNoTracking().ToListAsync());
            }

            var msg = "N'existe pas!";
           
            return RedirectToAction("Index",ViewData[$"{msg}"]);
        }
    }
}
