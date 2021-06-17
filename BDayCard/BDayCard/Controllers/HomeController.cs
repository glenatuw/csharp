using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDayCard.Models;

namespace BDayCard.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Card());
        }

        [HttpPost]
        public IActionResult Index(Card card)
        {
            if (ModelState.IsValid)
            {
                return View("SubmitCard", card);
            }
            else
            {
                return View(card);
            }
        }
    }
}
