using Microsoft.EntityFrameworkCore;
using newapi.domain.entities;

namespace newapi.infra.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    // public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.OwnsOne(u => u.Email, emailOwned =>
            {
                emailOwned.Property(e => e._email).HasColumnName("Email").IsRequired();
                emailOwned.HasIndex(e => e._email).IsUnique();
            });

            entity.OwnsOne(u => u.Password, passwordOwned =>
            {
                passwordOwned.Property(p => p._password).HasColumnName("Password").IsRequired();
            });
            entity.OwnsOne(u => u.Profile, profileOwned =>
            {
                profileOwned.Property(profile => profile._profile).HasColumnName("Profile").IsRequired();
            });
        });
    }
}
