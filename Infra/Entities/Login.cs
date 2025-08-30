using System.ComponentModel.DataAnnotations;

namespace newapi.domain.entities;

public abstract class Login
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    [StringLength(100)]
    [MinLength(3)]
    public string Name { get; private set; } = default!;

    public virtual void CreateName(string name)
    {
        Name = name;
    }

    public virtual void UpdateName(string name)
    {
        if (Name == name)
        {
            return;
        }
        Name = name;
    }
}