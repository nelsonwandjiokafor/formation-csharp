Rechteck neuRechteck = new Rechteck(5, 5, "Rechteck");
neuRechteck.Anzeigen();

Kreis neuKreis = new Kreis(6, "Kreis");
neuKreis.Anzeigen();

List<IDruckbar> druckListe = new List<IDruckbar>();
druckListe.Add(neuRechteck);
druckListe.Add(neuKreis);

foreach (IDruckbar item in druckListe)
{
    item.Drucken();
}

interface IDruckbar
{
    void Drucken();
}

abstract class Form

{
    public string Name;

    public Form(string name)

    {
        Name = name;
    }

    public abstract double Flaeche();

    public abstract double Umfang();

    public void Anzeigen()

    {
        Console.WriteLine($"{Name}, {Flaeche():F2}, {Umfang():F2}");

    }


}

class Rechteck : Form, IDruckbar

{
    public double Breite;
    public double Hoehe;

    public Rechteck(double breite, double hoehe, string name) : base(name)
    {
        Breite = breite;
        Hoehe = hoehe;
    }

    public void Drucken()
    {
        Console.WriteLine($"Rechteck drucken: Breite={Breite}, Höhe={Hoehe}");
    }

    public override double Flaeche()

    {
        return Breite * Hoehe;
    }

    public override double Umfang()
    {
        return 2 * (Breite + Hoehe);
    }
}
class Kreis : Form, IDruckbar

{
    public double Radius;

    public Kreis(double radius, string name) : base(name)

    {
        Radius = radius;
    }

    public void Drucken()
    {
        Console.WriteLine($"Kreis drucken: Radius={Radius}");
    }


    public override double Flaeche()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Umfang()
    {
        return 2 * Math.PI * Radius;
    }

}
