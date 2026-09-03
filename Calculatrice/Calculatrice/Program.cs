double LeseZahl(string nachricht)
{
    Console.Write(nachricht);
    return Convert.ToDouble(Console.ReadLine());
}

double Berechnen(double zahl1, double zahl2, string operateur)
{
    if (operateur == "+")
        return zahl1 + zahl2;
    else if (operateur == "-")
        return zahl1 - zahl2;
    else if (operateur == "*")
        return zahl1 * zahl2;
    else if (operateur == "/")
    {
        if (zahl2 == 0)
            return double.NaN;
        return zahl1 / zahl2;
    }
    else
        return double.NaN;
}

Console.WriteLine("Willkommen beim Taschenrechner");
bool weiter = true;
int anzahl = 0;

while (weiter)
{
    double zahl1 = LeseZahl("Gib die erste Zahl ein: ");

    Console.Write("Operator (+, -, *, /): ");
    string operateur = Console.ReadLine();

    double zahl2 = LeseZahl("Gib die zweite Zahl ein: ");

    double resultat = Berechnen(zahl1, zahl2, operateur);

    if (double.IsNaN(resultat))
    {
        Console.WriteLine("Fehler: Ungültige Berechnung");
    }
    else
    {
        Console.WriteLine($"Ergebnis: {resultat:F2}");
        anzahl++;
    }

    Console.Write("Nochmal? (ja/nein): ");
    string antwort = Console.ReadLine();
    if (antwort == "nein")
        weiter = false;
}

Console.WriteLine($"Du hast {anzahl} Berechnungen durchgeführt.");