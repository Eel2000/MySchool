using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Data;
using MySchool.Models;

namespace MySchool.Controllers
{
    public class ProfController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SelectList OptionNameSL { get; set; }



        public ProfController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void PopulateOptionsDropDownList(object selectedOption = null)
        {
            var OptionsQuery = from c in _dbContext.Options
                               orderby c.Designation //sort by designation
                               select c;

            ViewBag.OptionNameSL = new SelectList(OptionsQuery.AsNoTracking(), "OptionID", "Designation", selectedOption);

        }

        public IActionResult Index()
        {
            PopulateOptionsDropDownList();
            return View();
        }

        [HttpPost,ActionName("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProf([Bind("FirstName,LastName,Email,PhoneNumber,OptionID")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                var newProf = enseignant;

                await _dbContext.Enseignants.AddAsync(newProf);
                await _dbContext.SaveChangesAsync();

                await Task.Delay(2000);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListOfProf()
        {
            var profDisponible = await _dbContext.Enseignants
                .Include(p => p.Option)
                    .ThenInclude(p => p.Cours)
                        .ToListAsync();

            return View(profDisponible);
        }

        [HttpGet]
        public IActionResult DetailDuProf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prof = _dbContext.Enseignants
                .Where(p => p.EnseignantID == id)
                .Include(p => p.Option)
                    .ThenInclude(p => p.Cours)
                .ToList();

            return View(prof);
        }
    }
}
