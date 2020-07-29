﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Controllers
{
    public class CoursController : Controller
    {
        private readonly MySchool.Data.ApplicationDbContext _dbContext;

        public SelectList OptionSL { get; set; }
        public SelectList ProfSL { get; set; }

        public CoursController(Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void PopulateOptionsDropDownList(object selectedOption = null)
        {
            var OptionsQuery = from c in _dbContext.Options
                               orderby c.Designation //sort by designation
                               select c;

            ViewBag.OptionSL = new SelectList(OptionsQuery.AsNoTracking(), "OptionID", "Designation", selectedOption);

        }
        
        public void PopulateProfDropDownList(object selectedCours = null)
        {
            var ProfQuery = from c in _dbContext.Enseignants
                               orderby c.LastName //sort by designation
                               select c;

            ViewBag.ProfSL = new SelectList(ProfQuery.AsNoTracking(), "EnseignantID", "LastName", selectedCours);

        }

        

        public async Task<IActionResult> Index()
        {
         
            var listOfCours = await _dbContext.Cours
                .Include(c => c.Option)
                .Include(c => c.Enseignant)
                .ToListAsync();           

            return View(listOfCours);
        }

        [HttpGet]
        public IActionResult NewCours()
        {
            PopulateOptionsDropDownList();
            PopulateProfDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCours([Bind("DesignationCours,VolumeHoraire,Statu,OptionID,EnseignantID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                var nouveauCours = cours;

                await _dbContext.Cours.AddAsync(nouveauCours);
                await _dbContext.SaveChangesAsync();

                await Task.Delay(2000);
                return RedirectToAction("Index");
            }

            PopulateOptionsDropDownList();
            PopulateProfDropDownList();
            return View();
        }
    }
}
