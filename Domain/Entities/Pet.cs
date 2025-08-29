using newapi.ownedtypes;

namespace newapi.domain.entities;

public class Pet : Login
{
    public Breed Breed { get; private set; } = default!;
}