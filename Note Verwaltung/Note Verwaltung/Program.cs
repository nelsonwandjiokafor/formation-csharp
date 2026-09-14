using System.Text.Json;

Dictionary<string, double> nameNote = new Dictionary<string, double>();

if (File.Exists("noten.json"))
{
    string json = File.ReadAllText("noten.json");
    nameNote = JsonSerializer.Deserialize<Dictionary<string, double>>(json);
}


bool weiter = true;

while (weiter)
{
    Console.WriteLine();
    Console.WriteLine("=== NOTENVERWALTUNG ===");
    Console.WriteLine("1. Schüler und Note hinzufügen");
    Console.WriteLine("2. Note eines Schülers anzeigen");
    Console.WriteLine("3. Alle Schüler und Noten anzeigen");
    Console.WriteLine("4. Durchschnittsnote berechnen");
    Console.WriteLine("5. Beenden");
    Console.Write("Auswahl: ");

    string auswahl = Console.ReadLine();

    switch (auswahl)
    {
        case "1":
            Console.Write("Gibt dein Name ein: ");
            string name = Console.ReadLine();

            Console.Write("Gibt dein Note ein: ");
            double note = Convert.ToDouble(Console.ReadLine());

            nameNote.Add(name, note);

            Console.WriteLine($"{name} wurde hinzugefügt.");

            string json = JsonSerializer.Serialize(nameNote);
            File.WriteAllText("noten.json", json);

            break;


        case "2":
            Console.Write("Was ist dein Name:");
            string nameEingeben = Console.ReadLine();

            if (nameNote.ContainsKey(nameEingeben))
            {
                Console.WriteLine(nameNote[nameEingeben]);
            }
            else
            {
                Console.WriteLine($"error");
            }

            break;

        case "3":

            foreach (var paar in nameNote)
            {
                Console.WriteLine($"{paar.Key}: {paar.Value}");
            }

            break;

        case "4":

            double summe = 0;
            foreach (var paar in nameNote)
            {
                summe = summe + paar.Value;
            }
            double durchschnitt = summe / nameNote.Count;

            Console.WriteLine($"Durchschnittsnote: {durchschnitt:F2}");

            break;

        case "5":

            weiter = false;

            break;

        default:

            Console.WriteLine("Ungültige Auswahl.");

            break;
    }
}