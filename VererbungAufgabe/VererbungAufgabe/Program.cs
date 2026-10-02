Person meinPerson = new Person("Nelson", 32);
meinPerson.Vorstellen();

Mitarbeiter meinMitarbeiter = new Mitarbeiter("Entwickler", "Nelson", 32);
meinMitarbeiter.Arbeiten();
meinMitarbeiter.Vorstellen();

Student meinStudent = new Student("Informatik", "Nelson", 32);
meinStudent.Studieren();
meinStudent.Vorstellen();



class Person 
{
    public string Name;
    public int Alter;

    public Person (string name, int alter) 
    {
        Name = name;
        Alter = alter;
    
    
    }

    public void Vorstellen()
    {

        Console.WriteLine($"Ich bin {Name}, {Alter} jahre alt ");
    
    
    }

}


class Mitarbeiter : Person 

{
    public string Position;

    public Mitarbeiter (string position, string name, int alter) : base (name, alter)
    
    {
        Position = position;
     
    }

    public void Arbeiten() 
    
    {

        Console.WriteLine($"{Name} arbeitet als {Position}");
    
    
    }




}

class Student : Person 

{

    public string Studiengang;

    public Student(string studiengang, string name, int alter) : base(name, alter) 
    
    {

        Studiengang = studiengang;
    
      
    }

    public void Studieren() 
    
    {
        Console.WriteLine($"{Name} studiert {Studiengang}");
    
    
    }


}

