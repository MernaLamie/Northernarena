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
    public class AboutUsController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public AboutUsController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<AboutUsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var AboutUsLst = await _Conntext.AboutUs.ToListAsync();
                if (AboutUsLst.Count() == 0)
                    return Ok(new AboutUS());
                else
                    return Ok(AboutUsLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        //// GET api/<AboutUsController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var AboutUs = await _Conntext.AboutUs.FindAsync(id);
        //        if (AboutUs == null)
        //            return Ok(new AboutUS());
        //        else
        //            return Ok(AboutUs);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // POST api/<AboutUsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AboutUsDto _AboutUs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var AboutUs = _mapper.Map<AboutUS>(_AboutUs);
                    AboutUs.Image = (await upload.UploadImage(Request))[0];
                    await _Conntext.AboutUs.AddAsync(AboutUs);
                    await _Conntext.SaveChangesAsync();
                    return Ok(AboutUs);
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

   



// PUT api/<AboutUsController>/5
[HttpPut("{id}")]
public async Task<IActionResult> Put([FromBody] AboutUS _updatedAboutUs)
{
    try
    {
        if (ModelState.IsValid)
        {
            //if (_updatedAboutUs.Image != null)
            //{
            //    var img = (await upload.UploadImage(Request))[0];
               
            //}

            _Conntext.Update(_updatedAboutUs);
            await _Conntext.SaveChangesAsync();
            return Ok(_updatedAboutUs);
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

        // DELETE api/<AboutUsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedAboutUs = await _Conntext.AboutUs.FindAsync(id);
                    _Conntext.Remove(DeletedAboutUs);
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

