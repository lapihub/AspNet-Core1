using Infrastructure.Entities;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create(string firstName, string lastName, string email)
    {
        try
        {
            return new UserEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email
            };
        }
        catch { }
        return null!;
    }
}