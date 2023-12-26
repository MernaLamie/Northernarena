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
    public class IntroController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public IntroController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<IntroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var IntroLst = await _Conntext.Intro.ToListAsync();
                if (IntroLst.Count() == 0)
                    return Ok(new Intro());
                else
                    return Ok(IntroLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        // GET api/<IntroController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Intro = await _Conntext.Intro.FindAsync(id);
                return Ok(Intro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<IntroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IntroDto _Intro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Intro =_mapper.Map<Intro>(_Intro);
                    Intro.Image= (await upload.UploadImage(Request))[0];
                    await _Conntext.Intro.AddAsync(Intro);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Intro);
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





        // PUT api/<IntroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Intro _updatedIntro)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _Conntext.Update(_updatedIntro);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedIntro);
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

        // DELETE api/<IntroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedIntro = await _Conntext.Intro.FindAsync(id);
                    _Conntext.Remove(DeletedIntro);
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

