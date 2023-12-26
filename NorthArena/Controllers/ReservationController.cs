using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthArena.Dtos;
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
                if (ReservationLst.Count() == 0)
                    return Ok(new List<Reservation>());
                else
                    return Ok(ReservationLst);
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

        [HttpPost]
        [Route("PostTicketPrice")]
        public async Task<IActionResult> Post([FromBody] TicketPrice ticketPrice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    await _Conntext.ticketPrices.AddAsync(ticketPrice);
                    await _Conntext.SaveChangesAsync();
                    return Ok(ticketPrice);
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

        [HttpGet]
        [Route("GetTicketPrice")]
        public async Task<IActionResult> GetTicketPrices()
        {
            try
            {
                var ticketPricesLst = await _Conntext.ticketPrices.ToListAsync();
                if (ticketPricesLst.Count() == 0)
                    return Ok(new List<Reservation>());
                else
                    return Ok(ticketPricesLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        //// PUT api/<ReservationController>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put([FromBody] Reservation _updatedReservation)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
               
        //            _Conntext.Update(_updatedReservation);
        //            await _Conntext.SaveChangesAsync();
        //            return Ok(_updatedReservation);
        //        }
        //        else
        //        {
        //            return UnprocessableEntity(ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //// DELETE api/<ReservationController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var DeletedReservation = await _Conntext.Reservations.FindAsync(id);
        //            _Conntext.Remove(DeletedReservation);
        //            await _Conntext.SaveChangesAsync();
        //            return Ok("");
        //        }
        //        else
        //        {
        //            return UnprocessableEntity(ModelState);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

    