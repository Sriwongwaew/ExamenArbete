using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mood2.Data;
using Mood2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mood2.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoodService moodService;

        public HomeController(MoodService moodService)
        {
            this.moodService = moodService;
        }
        [Route("")]
        public IActionResult Index()
        {
            moodService.SetUpDatabaseIfItsNotAlreadySetup();
            return RedirectToAction("Index", "Moody");
        }

    }
}
