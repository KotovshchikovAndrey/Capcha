namespace OOP_ICT.Second.Abstractions;

public class Player
{
    public Guid Uuid { get; }
    public string Name { get; }
    public string Surname { get; }

    public Player(Guid uuid, string name, string surname)
    {
        Uuid = uuid;
        Name = name;
        Surname = surname;
    }
    
    public Player(string name, string surname)
    {
        Uuid = new Guid();
        Name = name;
        Surname = surname;
    }
}