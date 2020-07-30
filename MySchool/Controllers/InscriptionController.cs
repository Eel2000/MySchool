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
    public class InscriptionController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SelectList CategoryNameSL { get; set; }
        public SelectList ParentsSL { get; set; }

        public InscriptionController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //creating method for populating Option from db      
        public void PopulateOptionsDropDownList(object selectedOption = null)
        {
            var OptionsQuery = from c in _dbContext.Options
                               orderby c.Designation //sort by designation
                               select c;

            ViewBag.CategoryNameSL = new SelectList(OptionsQuery.AsNoTracking(), "OptionID", "Designation", selectedOption);

        }
        public void PopulateParentsDropDownList(object selectedOption = null)
        {
            var OptionsQuery = from c in _dbContext.Parents
                               orderby c.LastName //sort by designation
                               select c;

            ViewBag.ParentsSL = new SelectList(OptionsQuery.AsNoTracking(), "ParentID", "LastName", selectedOption);

        }


        public IActionResult Index()
        {
            PopulateOptionsDropDownList();
            PopulateParentsDropDownList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Parents()
        {
            var parentAvailable = await _dbContext.Parents.
                Include(p => p.Enfants)
                .ToListAsync();

            return View(parentAvailable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("FirstName,LastName,Email,Grade,OptionID,ParentID")] Enfants enfants)
        {
            if (ModelState.IsValid)
            {
                var NewEnfant = enfants;
                
                await _dbContext.Enfants.AddAsync(NewEnfant);
                await _dbContext.SaveChangesAsync();

                await Task.Delay(1000);
               

                return RedirectToAction("Index", "Home");
            }

            PopulateOptionsDropDownList();
            PopulateParentsDropDownList();

            return View();
        }


        [HttpGet]
        public IActionResult AddParent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParent([Bind("FirstName,LastName,Email,Phone,AdresseTuteur")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                var newParent = parent;

                await _dbContext.Parents.AddAsync(newParent);
                await _dbContext.SaveChangesAsync();

                await Task.Delay(1000);
                return RedirectToAction("Index", "Inscription");
            }

            return View();
        }

        [HttpGet]
        public IActionResult DetailsParents(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentLoaded = _dbContext.Parents
                .Where(p => p.ParentID == id)
                .Include(p => p.Enfants)
                    .ThenInclude(e => e.Option)
                 .ToList();

            return View(parentLoaded);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateParent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentToUpdate = await _dbContext.Parents
                .FirstOrDefaultAsync(p => p.ParentID == id);

            return View(parentToUpdate);
        }

        [HttpPost, ActionName("UpdateParentPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateParentPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentToUpdate = await _dbContext.Parents
                .FirstOrDefaultAsync(p => p.ParentID == id);

                if (await TryUpdateModelAsync<Parent>(parentToUpdate, "",
                    p => p.FirstName, p => p.LastName, p => p.Email, p => p.Phone, p => p.AdresseTuteur))
                {
                    try
                    {
                        await _dbContext.SaveChangesAsync();


                        await Task.Delay(1000);
                        return RedirectToAction("Parents", "Inscription");
                    }
                    catch (DbUpdateException)
                    {

                        ModelState.AddModelError("", "Impossible de mettre a jour les information entrees" +
                            "veuillez svp reessayer.");
                    }
                }

            //}

            return View("UpdateParent", parentToUpdate);
        }

    }
}
