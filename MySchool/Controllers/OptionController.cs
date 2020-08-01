using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Controllers
{
    public class OptionController : Controller
    {
        private readonly MySchool.Data.ApplicationDbContext _dbContext;

        public OptionController(Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var optionAvailable = await _dbContext.Options
                .Include(o => o.Cours)
                .Include(o => o.Enfants)
                .ToListAsync();
            return View(optionAvailable);
        }

        [HttpGet]
        public IActionResult AddOption()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOption([Bind("Designation")] Option option)
        {
            if (ModelState.IsValid)
            {
                var newOption = option;

                await _dbContext.Options.AddAsync(newOption);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var option = _dbContext.Options.Include(o => o.Cours).ToList();
            var optLoad = _dbContext.Options
                .Where(o => o.OptionID == id)
                .Include(o => o.Cours)
                    .ThenInclude(o => o.Enseignant)
                .Include(o => o.Enfants)
                .ToList();

            return View(optLoad);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOption(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optionToUpdate = await _dbContext.Options
                .FirstOrDefaultAsync(o => o.OptionID == id);

            return View(optionToUpdate);
        }

        [HttpPost, ActionName("UpdateOption")]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> UpdateOptionPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optionToUpdate = await _dbContext.Options.FirstOrDefaultAsync(o => o.OptionID == id);

            if (await TryUpdateModelAsync<Option>(optionToUpdate,"",
                o => o.Designation))
            {
                try
                {
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch(DbException ex)
                {
                    ViewBag.erro = ex.Message;
                    return View();
                }
            }

            return View(optionToUpdate);
        }
    }
}
