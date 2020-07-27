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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("FirstName,LastName,Email,Grade,OptionID,ParentID")] Enfants enfants)
        {
            if (ModelState.IsValid)
            {
                var NewEnfant = enfants;
                //if (await TryUpdateModelAsync<Enfants>(NewEnfant,"enfant",
                //    e => e.EnfantID, e =>e.FirstName,e =>e.LastName, e =>e.Email, e =>e.Grade, e => e.OptionID))
                //{
                    await _dbContext.Enfants.AddAsync(NewEnfant);
                    await _dbContext.SaveChangesAsync();

                     await Task.Delay(2000);
               // }

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
        public async Task<IActionResult> AddParent([Bind("FirstName,LastName,Email,Phone")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                var newParent = parent;

                await _dbContext.Parents.AddAsync(newParent);
                await _dbContext.SaveChangesAsync();

                await Task.Delay(2000);
                return RedirectToAction("Index", "Inscription");
            }

            return View();
        }

    }
}
