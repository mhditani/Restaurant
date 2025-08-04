using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.IRepositories
{
    public interface ITokenRepo
    {
        string createJwToken(IdentityUser user, List<string> roles);
    }
}
