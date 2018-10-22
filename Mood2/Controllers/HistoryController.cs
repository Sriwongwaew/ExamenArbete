using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mood2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood2.Controllers
{
    public class HistoryController : Controller
    {
        public readonly ApplicationDbContext _context;

        public HistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: History
        public async Task<IActionResult> Index()
        {
            return View(await _context.History.Include(x => x.EmotionData).ToListAsync());
        }
    }
}
