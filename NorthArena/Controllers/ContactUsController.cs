using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthArena.Models;

namespace NorthArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
        private readonly IMapper _mapper;

        public ContactUsController(ApplicationDBContext Context, IMapper mapper)
        {
            _Conntext = Context;
            _mapper = mapper;
        }

        // GET: api/<ContactUsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ContactUsLst = await _Conntext.ContactUs.ToListAsync();
                return Ok(_mapper.Map<List<ContactUs>>(ContactUsLst));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





      

        // POST api/<ContactUsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactUs _ContactUs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ContactUs = _ContactUs;
                    await _Conntext.ContactUs.AddAsync(ContactUs);
                    await _Conntext.SaveChangesAsync();
                    return Ok(ContactUs);
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





        // PUT api/<ContactUsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ContactUs _updatedContactUs)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _Conntext.Update(_updatedContactUs);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedContactUs);
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

        // DELETE api/<ContactUsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedContactUs = await _Conntext.ContactUs.FindAsync(id);
                    _Conntext.Remove(DeletedContactUs);
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

    
  