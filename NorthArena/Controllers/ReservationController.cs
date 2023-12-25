using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthArena.Models;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDBContext _Conntext;
     

        public ReservationController(ApplicationDBContext Context)
        {
            _Conntext = Context;
      
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ReservationLst = await _Conntext.Reservations.ToListAsync();
                return Ok(ReservationLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Reservation = await _Conntext.Reservations.FindAsync(id);
                return Ok(Reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation _Reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Reservation = _Reservation;
                    await _Conntext.Reservations.AddAsync(Reservation);
                    await _Conntext.SaveChangesAsync();
                    return Ok(Reservation);
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





        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Reservation _updatedReservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
               
                    _Conntext.Update(_updatedReservation);
                    await _Conntext.SaveChangesAsync();
                    return Ok(_updatedReservation);
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

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DeletedReservation = await _Conntext.Reservations.FindAsync(id);
                    _Conntext.Remove(DeletedReservation);
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

    