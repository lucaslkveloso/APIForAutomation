using APIForAutomation.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIForAutomation.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APIForAutomation.Api.Controllers
{
    [Route("Address")]
    public class AddressController : ControllerBase
    {
        private readonly Context _context;

        public AddressController(Context context)
        {
            _context = context;
        }

        [Route("AdressList")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Addresses.ToListAsync();
        }

        [Route("ListAddress/{id}")]
        [HttpGet]
        public async Task<ActionResult<Address>> Get_Address(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [Route("CreateAddress")]
        [HttpPost]
        public async Task<ActionResult<Address>> Post_Address(Address address)
        {
            _context.Addresses.Add(address);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AddressExists(address.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get_Address", new { id = address.Id }, address);
        }

        [Route("ModifyAddress/{id}")]
        [HttpPut]
        public async Task<IActionResult> Put_Address(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Route("DeleteAddress/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Address>> Delete_Address(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
