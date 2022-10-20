using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payments.Entities;
using Payments.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Controllers {

    [Produces("application/xml")]
    [ApiController]
    [Route("[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly Context _context;

        public ParentController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public Task CreateAccount(ParentViewModel parentViewModel)
        {
            var parent = new Parent()
            {
                Provid=parentViewModel.Provid,
                AccNum = parentViewModel.AccNum,
                FullName = parentViewModel.FullName
            };
            _context.Parents.Add(parent);
            return _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<List<ParentViewModel>> GetAllAccount()
        {
            var parents = await _context.Parents.ToListAsync();
            var parentViewModels = new List<ParentViewModel>();
            foreach (var parent in parents)
            {
                parentViewModels.Add(new ParentViewModel()
                { Id = parent.Id, FullName = parent.FullName,Provid=parent.Provid, AccNum = parent.AccNum });
            }

            return parentViewModels;
        }
    } }