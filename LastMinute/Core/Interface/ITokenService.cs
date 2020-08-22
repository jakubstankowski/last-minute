using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Interface
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);

    }
}
