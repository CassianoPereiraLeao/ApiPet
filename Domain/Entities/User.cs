using System.ComponentModel.DataAnnotations;
using newapi.ownedtypes;

namespace newapi.domain.entities;

public class User : Login
{
    [Required]
    [EmailAddress]
    [MinLength(8)]
    [MaxLength(120)]
    public Email Email { get; private set; } = default!;
    [Required]
    [MinLength(8)]
    public Password Password { get; private set; } = default!;  
    public Guid PetId { get; set; } = default!;

    public void CreateEmail(Email email)
    {
        Email = email;
    }

    public void CreatePassword(Password password)
    {
        // faz a mesma coisa q UpdatePassword mas especifiquei para idiotas
        var passwordHash = Password.ToHash(password);
        Password = new Password(passwordHash);
    }

    public void UpdatePassword(Password password)
    {
        var passwordHash = Password.ToHash(password);
        Password = new Password(passwordHash);
    }
}