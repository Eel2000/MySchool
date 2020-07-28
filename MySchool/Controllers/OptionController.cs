using System;
using System.Collections.Generic;
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
            var optionAvailable = await _dbContext.Options.Include(o => o.Cours).ToListAsync();
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
                .Include(o => o.Cours).ToList();

            return View(optLoad);
        }
    }
}
