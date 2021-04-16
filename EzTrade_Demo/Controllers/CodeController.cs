using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using EzTrade_Demo.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace EzTrade_Demo.Controllers
{
    public class CodeController : Controller
    {
        private readonly CodeDetailsBLL _dB;
        private readonly ILogger<CodeController> _logger;
        private readonly IHubContext<CounterHub> _hubContext;

        public CodeController(CodeDetailsBLL db, ILogger<CodeController> logger, IHubContext<CounterHub> hubContext)
        {
            _hubContext = hubContext;
            _logger = logger;
            _dB = db;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CodeDetails codeDetails)
        {
            if (ModelState.IsValid)
            {
                _dB.AddCodeDetails(codeDetails);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CodeDetails code = _dB.GetCodeDetailsById(id);
            ViewBag.code = code;
            if (code == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind] CodeDetails codeDetails, int? id)
        {
            if (id != codeDetails.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dB.UpdateCodeDetails(codeDetails);
                return RedirectToAction("Index");
            }
            return View(_dB);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CodeDetails code = _dB.GetCodeDetailsById(id);

            if (code == null)
            {
                return NotFound();
            }
            return View(code);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _dB.DeleteCodeDetails(id);
            return RedirectToAction("Index");

        }

        public IActionResult CRUD_API_JS()
        {
            return View();
        }
        public async Task<IActionResult> Monitor()
        {
            await _hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
            return View();
        }
    }
}
