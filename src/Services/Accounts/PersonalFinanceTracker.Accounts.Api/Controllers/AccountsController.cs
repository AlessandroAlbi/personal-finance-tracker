using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Accounts.Application.Dto;
using PersonalFinanceTracker.Accounts.Application.Mapping;
using PersonalFinanceTracker.Accounts.Domain.Entities;
using PersonalFinanceTracker.Accounts.Infrastructure.Persistance.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Accounts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region Private Properties
        private readonly AccountsDbContext _context;
        private readonly IMapper mapper = AutoMapperConfiguration.Configure().CreateMapper();
        #endregion

        public AccountsController(AccountsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var userGuid = new Guid("2090d106-eb86-4b82-9022-56f4ce652d85");
            var accounts = mapper.Map<IEnumerable<AccountDto>>(await _context.Accounts.Where(a => a.UserGuid == userGuid).ToListAsync());

            if (!accounts.Any())
                return NotFound();

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccountDto>> GetAccount(long id)
        {
            var userGuid = Guid.NewGuid();
            var account = mapper.Map<AccountDto>(await _context.Accounts.Where(a => a.UserGuid == userGuid && a.Id == id).FirstOrDefaultAsync());

            if (account == null)
                return NotFound();

            return account;
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> PutAccount(long id, AccountForUpdateDto accountForUpdate)
        {
            var userGuid = Guid.NewGuid();
            var account = mapper.Map<Account>(accountForUpdate);

            if (id != account.Id || userGuid != account.UserGuid)
                return BadRequest();

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> PostAccount([FromBody] AccountForCreationDto accountForCreationDto)
        {
            var userGuid = Guid.NewGuid();
            var account = mapper.Map<Account>(accountForCreationDto);
            account.UserGuid = userGuid;

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { userGuid = account.UserGuid, id = account.Id }, account);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAccount(long id)
        {
            var userGuid = Guid.NewGuid();
            var account = await _context.Accounts.Where(a => a.UserGuid == userGuid && a.Id == id).FirstOrDefaultAsync();
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(long id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
