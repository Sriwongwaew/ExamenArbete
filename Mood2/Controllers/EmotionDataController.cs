using Microsoft.AspNetCore.Mvc;
using Mood2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood2.Controllers
{
    public class EmotionDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmotionDataController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
