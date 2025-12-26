using Abstractions.Validators;

namespace Infrastructure.CredentialsValidators;

public class CredentialsValidator : IAdminCredentialsValidator
{
    private readonly string _password;

    public CredentialsValidator(string password)
    {
        _password = password;
    }

    public bool ValidatePassword(string password)
    {
        return password == _password;
    }
}