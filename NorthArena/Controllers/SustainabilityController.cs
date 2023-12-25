using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthArena.Dtos;
using NorthArena.Helper;
using NorthArena.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SustainabilityController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public SustainabilityController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<SustainabiltyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var SustainabiltyLst = await _Conntext.Sustainabilities.ToListAsync();
                return Ok(SustainabiltyLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        // GET api/<SustainabiltyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Sustainabilty = await _Conntext.Sustainabilities.FindAsync(id);
                return Ok(Sustainabilty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SustainabiltyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] SustainabilityDto _Sustainabilty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Sustainabilty =_mapper.Map<Sustainability> (_Sustainabilty);
                    Sustainabilty.Image= (await upload.UploadImage(Request))[0];
                    await _Conntext.Sustainabilities.AddAsync(Sustainabilty);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Sustainabilty);
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<SustainabiltyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Sustainability _updatedSustainabilty)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _Conntext.Update(_updatedSustainabilty);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedSustainabilty);
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SustainabiltyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedSustainabilty = await _Conntext.Sustainabilities.FindAsync(id);
                    _Conntext.Remove(DeletedSustainabilty);
                    await _Conntext.SaveChangesAsync();
                    return Ok("");
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

