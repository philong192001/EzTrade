using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EzTrade_Demo.Models;
using BLL;
using DAL.Models;

namespace EzTrade_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeBLL _dB;
        private readonly ILogger<HomeController> _logger;

        public HomeController(CodeBLL db, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dB = db;
        }

        public IActionResult Index()
        {
            List<Code> listcode = new List<Code>();
            listcode = _dB.GetAllCode().ToList();
            return View(listcode);
        }

        public IActionResult Create()
        {          
            var listCodeDetails = _dB.GetCodes();          
            ViewBag.lstCodeDetail = listCodeDetails;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Code code)
        {
            if (ModelState.IsValid)
            {
                _dB.AddCode(code);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Code code = _dB.GetCodeById(id);
            ViewBag.code = code;
            if (code == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int? id ,[Bind] Code code)
        {
            if (id != code.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dB.UpdateCode(code);
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
            Code code = _dB.GetCodeById(id);

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
            _dB.DeleteCode(id);
            return RedirectToAction("Index");
        }
        public IActionResult DemoSignalR()
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
