using JobGetter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.BL.IRepository
{
   public interface IAuthenRep
    {
        Task<AuthenticationModel> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> GetTokenAsync(TokenModel model);
        Task<string> addRoleAsync(AddRoleModel model);
    }
}
