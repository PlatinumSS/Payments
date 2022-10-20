using Payments.Entities;
using Payments.ViewModels;
using System.Collections.Generic;

namespace Payments.Mapper {

    public static class Mappers
    {
        public static List<AccountViewModel> MapAccountsToAccountViewModels(List<Account> accounts)
        {
            var accountViewModels = new List<AccountViewModel>();
            if (accounts is null)
                return accountViewModels;
            foreach (var account in accounts)
            {
                accountViewModels.Add(new AccountViewModel()
                { Id = account.Id, Info = account.Info, Product = account.Product, AccNum = account.AccNum });
            }

            return accountViewModels;
        }

        public static AccountViewModel MapAccountToAccountViewModel(Account account)
        {
            return new AccountViewModel()
            { Id = account.Id, Info = account.Info, Product = account.Product, AccNum = account.AccNum };
        }

        public static List<ParentViewModel> MapParentsToParentViewModel(List<Parent> parents)
        {
            var parentViewModels = new List<ParentViewModel>();
            if (parents is null)
                return parentViewModels;
            foreach (var parent in parents)
            {
                parentViewModels.Add(new ParentViewModel()
                { Id = parent.Id, FullName = parent.FullName, Provid=parent.Provid, AccNum = parent.AccNum });
            }

            return parentViewModels;
        }

        public static ParentViewModel MapParentToParentViewModel(Parent parent)
        {
            return new ParentViewModel() { Id = parent.Id,Provid=parent.Provid, FullName = parent.FullName, AccNum = parent.AccNum };
        }
    } }