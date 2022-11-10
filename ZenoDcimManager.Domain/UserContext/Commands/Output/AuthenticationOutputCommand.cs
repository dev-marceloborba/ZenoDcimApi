using System;

namespace ZenoDcimManager.Domain.UserContext.Commands.Output
{
    public class UserDataOutputCommand
    {
        public UserDataOutputCommand() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class AuthenticationOutputCommand
    {
        public string Token { get; set; }
        public UserDataOutputCommand User { get; set; }

        public AuthenticationOutputCommand(string token, string name, string email, Guid id)
        {
            Token = token;
            User = new UserDataOutputCommand();
            User.Name = name;
            User.Email = email;
            User.Id = id;
        }
    }
}