using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payments.Entities;
using Payments.Mapper;
using Payments.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Controllers
{

    [Produces("application/xml")]
    [ApiController]
    [Route("[controller]/requests/action")]
    public class PaymentController : ControllerBase
    {
        private readonly Context _context;

        public PaymentController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public Task<ResponseViewModel> GetAccounts([FromQuery] RequestViewModel viewModel)
        {
            switch (viewModel.Type)
            {
                case 1:
                    return RequestType1(viewModel);
                case 2:
                    return RequestType2(viewModel);
            }

            throw new ArgumentException("invalid request type");
        }

        private async Task<ResponseViewModel> RequestType1(RequestViewModel model)
        {
            var parent = await _context.Parents.Where(parent => parent.AccNum == model.ClientCode)
                .Include(parent1 => parent1.Children).FirstOrDefaultAsync();
            if (parent is null)
                return new ResponseViewModel() { Status = 6, Msg = "Идентификатор абонента не существует" };
            var accountViewModels = Mappers.MapAccountsToAccountViewModels(parent?.Children);

            return new ResponseViewModel
            { Status = 5, Msg = parent.FullName, Accounts = accountViewModels, Count = accountViewModels.Count };
        }

        private async Task<ResponseViewModel> RequestType2(RequestViewModel model)
        {
            var account = await _context.Accounts.Where(account => account.AccNum == model.ContractId)
                .FirstOrDefaultAsync();
            if (account is null)
                return new ResponseViewModel() { Status = 6, Msg = " Идентификатор абонента не существует" };
            if (model.Summa is null)
                return new ResponseViewModel() { Status = 1, Msg = "Пустой параметр в запросе" };
            if (model.ContractId is null)
                return new ResponseViewModel() { Status = 1, Msg = "Пустой параметр в запросе" };
            if (model.Tranzid is null)
                return new ResponseViewModel() { Status = 9, Msg = "Неправильный тип запроса" };

            var payment = await _context.Payments.Where(payment => payment.TranzId == model.Tranzid).FirstOrDefaultAsync();

            if (payment !=null)
                return new ResponseViewModel() { Status = 7, Msg = "Дублирование проведения платежа" };
            _context.Payments.Add(new Payment()
            {
                Summa = model.Summa.Value,
                ContractId = model.ContractId.Value,
                DateTime = model.Date,
                TranzId = model.Tranzid.Value
            });
            await _context.SaveChangesAsync();
            return new ResponseViewModel() { Status = 4, Msg = "Платеж успешно принят" };
        }
    }
}