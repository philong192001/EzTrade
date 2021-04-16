using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<SignalRHub> _signalrhub;

        public ServerController(IHubContext<SignalRHub> signalrhub)
        {
           _signalrhub = signalrhub;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.number = ConnectedUser.Ids.Count();
            return View();
        }
    }
}
