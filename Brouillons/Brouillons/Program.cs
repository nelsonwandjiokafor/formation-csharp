Rechteck neuRechteck = new Rechteck(5, 5, "Rechteck");
neuRechteck.Anzeigen();

Kreis neuKreis = new Kreis(6, "Kreis");
neuKreis.Anzeigen();


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
        Console.WriteLine ($"{Name}, {Flaeche():F2}, {Umfang():F2}"); 
    
    }


}

class Rechteck : Form 

{
    public double Breite;
    public double Hoehe;

    public Rechteck(double breite, double hoehe, string name ) : base (name)
    {
     Breite = breite;
     Hoehe = hoehe;
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
class Kreis : Form 

{
    public double Radius;

    public Kreis(double radius, string name) : base(name)

    { 
        Radius = radius;
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

    



