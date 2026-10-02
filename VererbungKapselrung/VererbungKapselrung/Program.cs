Person meinPerson = new Person("Nelson", 32);
meinPerson.Vorstellen();

Mitarbeiter meinMitarbeiter = new Mitarbeiter("Entwickler", "Nelson", 32);
meinMitarbeiter.Arbeiten();
meinMitarbeiter.Vorstellen();
meinMitarbeiter.Befoerdern("Senior Entwickler");
meinMitarbeiter.Arbeiten();

Student meinStudent = new Student("Informatik", "Nelson", 32);
meinStudent.Studieren();
meinStudent.Vorstellen();
meinStudent.WechselStudiengang("Wirtschaftsinformatik");
meinStudent.Studieren();


class Person
{
    protected string Name;
    protected int Alter;

    public Person(string name, int alter)
    {
        this.Name = name;
        this.Alter = alter;
    }

    public string GetName() { return Name; }
    public int GetAlter() { return Alter; }

    public void Vorstellen()
    {
        Console.WriteLine($"Ich bin {Name}, {Alter} Jahre alt.");
    }
}


class Mitarbeiter : Person
{
    private string Position;

    public Mitarbeiter(string position, string name, int alter) : base(name, alter)
    {
        this.Position = position;
    }

    public string GetPosition() { return Position; }

    public void Arbeiten()
    {
        Console.WriteLine($"{Name} arbeitet als {Position}.");
    }

    public void Befoerdern(string neuePosition)
    {
        Position = neuePosition;
    }
}


class Student : Person
{
    private string Studiengang;

    public Student(string studiengang, string name, int alter) : base(name, alter)
    {
        this.Studiengang = studiengang;
    }

    public string GetStudiengang() { return Studiengang; }

    public void Studieren()
    {
        Console.WriteLine($"{Name} studiert {Studiengang}.");
    }

    public void WechselStudiengang(string neuerStudiengang)
    {
        Studiengang = neuerStudiengang;
    }
}