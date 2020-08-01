using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySchool.Data;

namespace MySchool.Controllers
{
    public class EleveController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EleveController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
