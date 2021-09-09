using EvoDcimManager.Shared.Entities;
using Flunt.Validations;

namespace EvoDcimManager.Domain.UserContext.ValueObjects
{
    public class Password : ValueObject
    {
        public Password(string initialPassword, string passwordConfirmation)
        {
            InitialPassword = initialPassword;
            PasswordConfirmation = passwordConfirmation;
        }

        public string InitialPassword { get; private set; }
        public string PasswordConfirmation { get; private set; }
    }
}