using Microsoft.AspNetCore.Identity;
using MovieShopMVC.Core.Contracts.Repository;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure.Service
{
    public class AccountServiceAsync : IAccountServiceAsync
    {
        private readonly IAccountRepositoryAsync accountRep;

        public AccountServiceAsync(IAccountRepositoryAsync accountRep)
        {
            this.accountRep = accountRep;
        }

        public Task<SignInResult> LoginAsync(SignInModel model)
        {
            return accountRep.LoginAsync(model);
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            return accountRep.SignUpAsync(model);
        }

       
    }
}
