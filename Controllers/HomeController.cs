using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab28a.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace Lab28a.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISession _session;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(LetsPlay play)
        {
            return View(play);
        } 

        public async Task<IActionResult> NewDeck()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://deckofcardsapi.com");

            var response = await client.GetAsync("api/deck/new/shuffle/");

            var content = await response.Content.ReadAsAsync<NewDeck>();

            if (content.Success)
            {
                var play = new LetsPlay();
                play.IsDeck = true;
                play.Remaining = content.Remaining;
                TempData["NewDeck"] = content;

                return View("Index", play);
            }

            return NotFound();
        }
        
        public async Task<IActionResult> DrawCard(int drawCards = 5)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            var newdeck = TempData["NewDeck"] as NewDeck;

           var response = await client.GetAsync("api/deck/new/" + newdeck.Deck_id + "/?count=" + drawCards.ToString());

            var content = await response.Content.ReadAsAsync<DrawCard>();

            if (content.IsGood)
            {
                var play = new LetsPlay();
                play.IsDeck = true;
                play.Remaining = content.Remaining;

                return View("Index", play);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
