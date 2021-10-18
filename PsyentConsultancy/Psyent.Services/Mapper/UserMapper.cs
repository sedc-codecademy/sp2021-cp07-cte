using Psyent.DataModels;
using Psyent.Models;

namespace Psyent.Services.Mapper
{
    public class UserMapper
    {
        public static User RegisterModelToUser(RegisterModel model)
        {
            return new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password
            };
        }
    }
}
