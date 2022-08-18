using Microsoft.AspNetCore.Identity;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Core.Contracts.Repository
{
    public interface IAccountRepositoryAsync
    {
        Task<IdentityResult> SignUpAsync(SignUpModel user);
        Task<SignInResult> LoginAsync(SignInModel model);

    }
}
