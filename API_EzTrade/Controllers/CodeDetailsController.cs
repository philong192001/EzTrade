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
    public class CodeDetailsController : ControllerBase
    {
        private readonly CodeDetailsBLL _dB;

        public CodeDetailsController(CodeDetailsBLL db)
        {
            _dB = db;
        }

        [HttpGet("{id}")]
        public CodeDetails GetAllCodeDetailsById(int id)
        {
            return _dB.GetCodeDetailsById(id);
        }

        [HttpPost]
        public IActionResult Create([Bind] CodeDetails codeDetails)
        {
            try
            {
                _dB.AddCodeDetails(codeDetails);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Ok(codeDetails);
        }

        [HttpPost]
        public IActionResult Update([Bind] CodeDetails codeDetails)
        {
            try
            {

                if (codeDetails == null)
                {
                    return BadRequest();
                }
                else
                {
                    _dB.UpdateCodeDetails(codeDetails);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (codeDetails.Price_TC == null && codeDetails.Price_Tran == null && codeDetails.Price_San == null )
            {
                return NotFound();
            }
            else
            {
                return Ok(codeDetails);
            }
        }

        [HttpPost("{id}")]
        public void Delete(int id)
        {
            _dB.DeleteCodeDetails(id);
        }
    }
}
