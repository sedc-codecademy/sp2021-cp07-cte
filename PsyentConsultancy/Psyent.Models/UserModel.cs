using System;

namespace Psyent.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{ FirstName } { LastName }";
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
