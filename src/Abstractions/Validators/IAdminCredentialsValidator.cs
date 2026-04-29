namespace Abstractions.Validators;

public interface IAdminCredentialsValidator
{
    bool ValidatePassword(string password);
}