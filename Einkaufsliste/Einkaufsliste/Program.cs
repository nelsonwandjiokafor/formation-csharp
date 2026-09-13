List<string> artikelListe = new List<string>();

if (File.Exists("einkaufsliste.txt"))
{
    string[] zeilen = File.ReadAllLines("einkaufsliste.txt");
    foreach (string zeile in zeilen)
    {
        artikelListe.Add(zeile);
    }
}

bool weiter = true;

while (weiter)
{
    Console.WriteLine();
    Console.WriteLine("=== EINKAUFSLISTE ===");
    Console.WriteLine("1. Artikel hinzufügen");
    Console.WriteLine("2. Artikel entfernen");
    Console.WriteLine("3. Alle Artikel anzeigen");
    Console.WriteLine("4. Artikel suchen");
    Console.WriteLine("5. Beenden");
    Console.Write("Auswahl: ");

    string auswahl = Console.ReadLine();

    switch (auswahl)
    {
        case "1":
            Console.Write("Artikelname: ");
            string neuerArtikel = Console.ReadLine();

            artikelListe.Add(neuerArtikel);

            Console.WriteLine($"{neuerArtikel} wurde hinzugefügt.");

            File.WriteAllLines("einkaufsliste.txt", artikelListe);

            break;


        case "2":
            Console.Write("Welchen Artikel möchtest du entfernen? ");
            string artikelEntfernen = Console.ReadLine();

            if (artikelListe.Contains(artikelEntfernen))
            {
                artikelListe.Remove(artikelEntfernen);
                Console.WriteLine($"{artikelEntfernen} wurde entfernt.");
            }
            else
            {
                Console.WriteLine("Fehler: Artikel nicht gefunden.");
            }

            File.WriteAllLines("einkaufsliste.txt", artikelListe);

            break;


        case "3":
            Console.WriteLine("=== DEINE ARTIKEL ===");

            for (int i = 0; i < artikelListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {artikelListe[i]}");
            }

            File.WriteAllLines("einkaufsliste.txt", artikelListe);

            break;

        case "4":
            Console.Write("Suchbegriff eingeben: ");
            string suchbegriff = Console.ReadLine();

            foreach (string artikel in artikelListe)
            {
                if (artikel.Contains(suchbegriff))
                {
                    Console.WriteLine($"Gefunden: {artikel}");
                }
            }


            break;

        case "5":
            Console.WriteLine($"Programm beendet. Insgesamt {artikelListe.Count} Artikel in der Einkaufsliste.");
            weiter = false;

            

            break;


        default:
            Console.WriteLine("Ungültige Auswahl. Bitte 1 bis 5 eingeben.");

          

            break;
    }
}



