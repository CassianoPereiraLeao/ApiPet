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

    public string? CreateEmail(Email email)
    {
        if (!email.IsValid())
        {
            return email.GetError();
        }
        Email = email;
        return null;
    }

    public string? UpdateEmail(Email newEmail)
    {
        if (newEmail.IsValid())
            return newEmail.GetError();

        Email = newEmail;
        return null;
    }

    public string? CreatePassword(Password password)
    {
        if (!password.IsValid())
        {
            return password.GetError();
        }

        var passwordHash = Password.ToHash(password);
        Password = new Password(passwordHash);
        return null;
    }

    public string? UpdatePassword(Password newPassword)
    {
        if (Password == null)
            return "Usuário não possui senha definida.";

        if (Password.Verify(newPassword.ToString()))
            return "A nova senha não pode ser igual à antiga.";

        if (!newPassword.IsValid())
        {
            return newPassword.GetError();
        }

        Password = new Password(Password.ToHash(newPassword));
        return Password.ToString();
    }
}