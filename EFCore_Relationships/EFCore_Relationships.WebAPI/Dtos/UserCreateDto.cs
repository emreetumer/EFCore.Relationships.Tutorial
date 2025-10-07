namespace EFCore_Relationships.WebAPI.Dtos;

public sealed record UserCreateDto(
    string FirstName,
    string LastName,
    string IdentityNumber,
    string FullAddress);
