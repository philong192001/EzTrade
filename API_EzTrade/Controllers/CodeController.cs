using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EzTrade.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly CodeBLL _dB;

        public CodeController(CodeBLL db)
        {
            _dB = db;
        }

        public IActionResult GetAllCode()
        {
            var code = _dB.GetAllCode().ToList();
            return Ok(code);
        }

        [HttpGet("{id}")]
        public Code Get(int id)
        {
            return _dB.GetCodeById(id);
        }

        [HttpPost]
        public IActionResult Create([Bind] Code code)
        {
            try
            {
                _dB.AddCode(code);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Ok(code);
        }

        [HttpPost]
        public IActionResult Update([Bind] Code code)
        {
            try
            {

                if (code == null)
                {
                    return BadRequest();
                }
                else
                {
                    _dB.UpdateCode(code);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (String.IsNullOrEmpty(code.NameCode))
            {
                return NotFound();
            }
            else
            {
                return Ok(code);
            }
        }

        [HttpPost("{id}")]
        public void Delete(int id)
        {
            _dB.DeleteCode(id);
        }
    }
}
