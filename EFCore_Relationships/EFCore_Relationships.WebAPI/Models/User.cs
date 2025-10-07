namespace EFCore_Relationships.WebAPI.Models;

public sealed class User
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public Guid UserInformationId { get; set; }
    public UserInformation? UserInformation { get; set; }
}

public sealed class UserInformation
{
    public UserInformation()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string IdentityNumber { get; set; } = default!;
    public string FullAddress { get; set; } = default!;
}