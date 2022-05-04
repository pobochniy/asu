using Atheneum.Dto.Auth;

namespace FunctionalTests.Arranges;

public static class ArrangeUsers
{
    public static readonly RegisterDto Vlad = new RegisterDto
    {
        UserName = "Vlad",
        Email = "vlad@email.ru",
        Phone = "+79091112234",
        Password = "123",
        PasswordConfirm = "123"
    };
}