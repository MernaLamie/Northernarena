using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthArena.Models;

namespace NorthArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
     
        public WebsiteController(ApplicationDBContext Context)
        {
            _Conntext = Context;
           
        }

        // GET: api/<WebsiteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var WebsiteLst = await _Conntext.WebsiteData.ToListAsync();
                return Ok(WebsiteLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        // GET api/<WebsiteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Website = await _Conntext.WebsiteData.FindAsync(id);
                return Ok(Website);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<WebsiteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WebSiteData _Website)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Website = _Website;
                    await _Conntext.WebsiteData.AddAsync(Website);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Website);
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





        // PUT api/<WebsiteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] WebSiteData _updatedWebsite)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _Conntext.Update(_updatedWebsite);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedWebsite);
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

        // DELETE api/<WebsiteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedWebsite = await _Conntext.WebsiteData.FindAsync(id);
                    _Conntext.Remove(DeletedWebsite);
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


