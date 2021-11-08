using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.UserContext.Validators
{
    public class LoginValidator : Notifiable
    {
        public LoginValidator(string source, string target)
        {
            AddNotifications(new Contract()
                .Requires()
                // .AreNotEquals(source, target, "Password", "Password doesn't match")
                .IsTrue(CheckDifferentPassword(source, target), "Password", "Password doesn't match")
            );
        }

        private bool CheckDifferentPassword(string source, string target)
        {
            Console.WriteLine("Source:" + source);
            Console.WriteLine("Target:" + target);
            var result = source.CompareTo(target) != 0;
            Console.WriteLine("Result:" + result);
            return source.CompareTo(target) != 0;
        }
    }
}