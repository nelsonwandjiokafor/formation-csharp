List<string> einkaufliste = new List<string>();
bool weiter = true; 

while(weiter) 

{
    Console.WriteLine("=== EINKAUFSLISTE ===");
    Console.WriteLine("1. Artikel hinzufügen");
    Console.WriteLine("2. Artikel entfernen=");
    Console.WriteLine("3. Alle Artikel anzeigen");
    Console.WriteLine("4. Artikel suchen");
    Console.WriteLine("5. Beenden");
    Console.Write("auswahl:");

    string auswahl = Console.ReadLine();

    switch(auswahl) 
    
    {
        case "1":

            Console.Write("Gibt dein artikel name ein:");
            string artikelName = Console.ReadLine();

            einkaufliste.Add(artikelName);

            break;

       
        
        case "2":

            Console.Write("Git dein Artikel Name ein:");
            string gesuchtArtikel = Console.ReadLine();
             
            if (einkaufliste.Contains(gesuchtArtikel)) 
            {
            
                einkaufliste.Remove(gesuchtArtikel);
            
            }

            else

            {

                Console.WriteLine("Name Existiert nicht: Error");

            }

            break;

        default:

            Console.WriteLine("Ungültige Eingabe ");

            break;




    }


  
       
}