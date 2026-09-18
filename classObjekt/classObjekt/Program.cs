// D'abord le code principal
Schueler schueler1 = new Schueler("Nelson", 32, 93);
schueler1.Anzeigen();
Console.WriteLine(schueler1.IstBestanden());
Console.WriteLine(schueler1.GetBewertung());

Schueler schueler2 = new Schueler("Landry", 30, 70);
schueler2.Anzeigen();
Console.WriteLine(schueler2.IstBestanden());
Console.WriteLine(schueler2.GetBewertung());

Schueler schueler3 = new Schueler("Loic", 50, 40);
schueler3.Anzeigen();
Console.WriteLine(schueler3.IstBestanden());
Console.WriteLine(schueler3.GetBewertung());

// Ensuite la classe en bas
class Schueler
{
    public string Name;
    public int Alter;
    public double Note;

    public Schueler(string name, int alter, double note)
    {
        Name = name;
        Alter = alter;
        Note = note;
    }

    public void Anzeigen()
    {
        Console.WriteLine($"{Name},{Alter} Jahre, Note:{Note:F2}");
    }

    public bool IstBestanden()
    {
        if (Note >= 50)
            return true;
        else
            return false;
    }

    public string GetBewertung()
    {
        if (Note >= 92)
            return "Sehr gut";
        else if (Note >= 81)
            return "Gut";
        else if (Note >= 67)
            return "Befriedigend";
        else if (Note >= 50)
            return "Ausreichend";
        else
            return "Nicht bestanden";
    }
}

