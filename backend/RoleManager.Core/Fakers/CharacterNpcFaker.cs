
public class CharacterNpcFaker : Faker<CharacterNpc>
{
    private readonly string _name;
    private readonly string _sex;
    private readonly string _race;

    public CharacterNpcFaker(string name = null, string sex = null, string race = null)
    {
        _name = name;
        _sex = sex;
        _race = race;

        RuleFor(c => c.Name, f => _name ?? f.Name.FullName());

        RuleFor(c => c.Sex, f => _sex ?? f.PickRandom(new[] { "Masculino", "Femenino", "No Binario" }));

        RuleFor(c => c.Race, f => _race ?? f.PickRandom(new[] { "Humano", "Elfo", "Enano", "Orco", "Hobbit", "Trol" }));
    }
}
