Produkt produkt1 = new Produkt("Biokaffe", 30, 50);
produkt1.Anzeigen();

produkt1.Verkaufen(10);     // OK — stock passe de 50 à 40
produkt1.Anzeigen();

produkt1.Verkaufen(999);    // erreur — pas assez de stock
produkt1.Anzeigen();

produkt1.SetPreis(-5);      // erreur — prix négatif
produkt1.Anzeigen();        // le prix doit rester 30

produkt1.Auffuellen(20);    // OK — stock passe de 40 à 60
produkt1.Anzeigen();

class Produkt

{
    private string name;
    private double preis;
    private int lagerbestand;

    public Produkt(string name, double preis, int lagerbestand)

    {
        this.name = name;
        this.preis = preis;
        this.lagerbestand = lagerbestand;

    }

    public string GetName() { return name; }

    public double GetPreis() { return preis; }

    public int GetLagerbestand() { return lagerbestand; }

    public void SetPreis(double neuerPreis)

    {
        if (neuerPreis > 0) { preis = neuerPreis; }

    }

    public void Verkaufen(int menge)

    {

        if (menge > 0 && menge <= lagerbestand) { lagerbestand -= menge; }

        else { Console.WriteLine("error"); }

    }

    public void Auffuellen(int menge)

    {
        if (menge > 0) { lagerbestand += menge; }
    }

    public void Anzeigen() { Console.WriteLine($"Name:{name}, Preis:{preis:F2}, Lagerbestand: {lagerbestand}"); }

}

