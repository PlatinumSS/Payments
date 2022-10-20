using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payments.Entities;
using Payments.Mapper;
using Payments.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Controllers {

    [Produces("application/xml")]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly Context _context;

        public AccountController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public Task CreateAccount(AccountViewModel account,[FromHeader] int parentId)
        {
            var account1 = new Account
            {
                Info = account.Info,
                Product = account.Product,
                AccNum = account.AccNum,
                ParentId = parentId
            };
            _context.Accounts.Add(account1);
            return _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<List<AccountViewModel>> GetAllAccount()
        {
            var accounts = await _context.Accounts.ToListAsync();
          
          var list=  Mappers.MapAccountsToAccountViewModels(accounts);
           
            return list;
        }
    } }