using Atheneum.Dto.Auth;
using Xunit;

namespace UnitTests;

public class LoginDtoTests
{
    [Theory]
    [InlineData("+79099184618")]
    [InlineData("+15551112233")]
    public void ShouldBePhone(string phone)
    {
        // Arrange
        var model = new LoginDto
        {
            Login = phone
        };
        
        // Act
        var isPhone = model.IsPhone;

        // Assert
        Assert.True(isPhone, "isPhone");
    }
    
    [Fact]
    public void PhoneShouldNotBeEmail()
    {
        // Arrange
        var model = new LoginDto
        {
            Login = "+79099184618"
        };
        
        // Act
        var isEmail = model.IsEmail;

        // Assert
        Assert.False(isEmail, "isEmail");
    }
    
    [Theory]
    [InlineData("jeer@yandex.ru")]
    [InlineData("koko@zz.rr")]
    public void ShouldBeEmail(string email)
    {
        // Arrange
        var model = new LoginDto
        {
            Login = email
        };
        
        // Act
        var isEmail = model.IsEmail;

        // Assert
        Assert.True(isEmail, "isEmail");
    }
    
    [Fact]
    public void EmailShouldNotBePhone()
    {
        // Arrange
        var model = new LoginDto
        {
            Login = "jeer@yandex.ru"
        };
        
        // Act
        var isPhone = model.IsPhone;

        // Assert
        Assert.False(isPhone, "isPhone");
    }
    
    [Theory]
    [InlineData("jeer")]
    [InlineData("123")]
    [InlineData("jeer@mail")]
    [InlineData("@mail.ru")]
    [InlineData("89099184618")]
    public void ShouldBeSimple(string login)
    {
        // Arrange
        var model = new LoginDto
        {
            Login = login
        };
        
        // Act
        var isPhone = model.IsPhone;
        var isEmail = model.IsEmail;

        // Assert
        Assert.False(isEmail, "isEmail");
        Assert.False(isPhone, "isPhone");
    }
}