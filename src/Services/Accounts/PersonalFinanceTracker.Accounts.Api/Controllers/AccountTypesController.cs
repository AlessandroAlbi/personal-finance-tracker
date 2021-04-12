using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Accounts.Application.Dto;
using PersonalFinanceTracker.Accounts.Application.Mapping;
using PersonalFinanceTracker.Accounts.Domain.Entities;
using PersonalFinanceTracker.Accounts.Infrastructure.Persistance.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Accounts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        #region Private Properties
        private readonly AccountsDbContext _context;
        private readonly IMapper mapper = AutoMapperConfiguration.Configure().CreateMapper();
        #endregion

        public AccountTypesController(AccountsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountTypeDto>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<AccountTypeDto>>> GetAccountTypes()
        {
            var accountTypes = mapper.Map<IEnumerable<AccountTypeDto>>(await _context.AccountTypes.ToListAsync());

            if (!accountTypes.Any())
                return NotFound();

            return Ok(accountTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccountTypeDto>> GetAccountType(long id)
        {
            var accountType = mapper.Map<AccountTypeDto>(await _context.AccountTypes.FindAsync(id));

            if (accountType == null)
                return NotFound();

            return accountType;
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountTypeDto>> PutAccountType(long id, AccountTypeForUpdateDto accountTypeForUpdate)
        {
            var accountType = mapper.Map<AccountType>(accountTypeForUpdate);

            if (id != accountType.Id)
                return BadRequest();

            _context.Entry(accountType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTypeExists(id))
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
        public async Task<ActionResult<AccountTypeDto>> PostAccountType([FromBody] AccountTypeForCreationDto accountTypeForCreationDto)
        {
            var accountType = mapper.Map<AccountType>(accountTypeForCreationDto);

            await _context.AccountTypes.AddAsync(accountType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountType", new { id = accountType.Id }, accountType);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAccountType(long id)
        {
            var accountType = await _context.AccountTypes.FindAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }

            _context.AccountTypes.Remove(accountType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountTypeExists(long id)
        {
            return _context.AccountTypes.Any(e => e.Id == id);
        }
    }
}
