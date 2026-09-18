int SichereEingabe(string nachricht)
{
    while (true)
    {


        try
        {
            Console.Write(nachricht);
            int zahl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Du hast {zahl} eingegeben.");

            return zahl;

        }

        catch (Exception e)
        {
            Console.WriteLine("Fehler! Bitte eine gültige Zahl eingeben.");

        }

    }

}

int alter = SichereEingabe("Gib dein Alter ein: ");
Console.WriteLine($"Dein Alter: {alter}");

int note = SichereEingabe("Gib deine Note ein: ");
Console.WriteLine($"Deine Note: {note}");