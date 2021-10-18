using Psyent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psyent.Services.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void Register(RegisterModel model);

    }
}
