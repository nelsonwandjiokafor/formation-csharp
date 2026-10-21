using Microsoft.Data.SqlClient;
using Mitarbeiterverwaltung;

string connectionString = "Server=localhost\\SQLEXPRESS;Database=Formation;Trusted_Connection=True;TrustServerCertificate=True;";
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

MitarbeiterRepository repo = new MitarbeiterRepository(connection);

bool weiter = true;

while (weiter)
 
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n=== MITARBEITERVERWALTUNG ===");
    Console.ResetColor();

    Console.WriteLine("1. Alle Mitarbeiter anzeigen");
    Console.WriteLine("2. Mitarbeiter suchen");
    Console.WriteLine("3. Neuen Mitarbeiter hinzufügen");
    Console.WriteLine("4. Mitarbeiter bearbeiten");
    Console.WriteLine("5. Mitarbeiter löschen");
    Console.WriteLine("6. Statistiken anzeigen");
    Console.WriteLine("7. Beenden");
    Console.Write("Auswahl: ");

    string auswahl = Console.ReadLine();

    switch (auswahl)
    {
        case "1":
            Console.WriteLine("== Liste Alle Mitarbeiter und Abteilungen == ");
           
            List<Mitarbeiter> liste = repo.GetAll();

            foreach (Mitarbeiter m in liste)
            {
                m.Anzeigen();
            }

            Console.WriteLine("\nDrücken Sie eine Taste...");
            Console.ReadKey();

            break;

        case "2":
            Console.WriteLine("== Mitarbeiter suchen ==");

            Console.Write("Vorname eingeben: ");
            string vorname = Console.ReadLine();

            bool gefunden = false;

            string sqlSuche = $"SELECT Vorname, Nachname FROM Mitarbeiter WHERE Vorname LIKE '%{vorname}%'";
            SqlCommand commandSuche = new SqlCommand(sqlSuche, connection);

            SqlDataReader reader2 = commandSuche.ExecuteReader();

            while (reader2.Read())

            {
                gefunden = true;

                Console.WriteLine($"{reader2["Vorname"]} - {reader2["Nachname"]}");

            }

            reader2.Close();

            if (!gefunden) 
            
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kein Mitarbeiter gefunden");
                Console.ResetColor();
                                
            }
                           
            Console.WriteLine("\nDrücken Sie eine Taste...");
            Console.ReadKey(true);

            break;

        case "3":

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("== Neuen Mitarbeiter hinzufügen ==");
            Console.ResetColor();
            
            try
            {
                Console.Write("Vorname eingeben: ");
                string neueVorname = Console.ReadLine();

                Console.Write("Nachname eingeben: ");
                string neueNachname = Console.ReadLine();

                Console.Write("AbteilungID eingeben: ");
                int neueAbteilung = Convert.ToInt32(Console.ReadLine());

                Console.Write("Gehalt eingeben: ");
                decimal neuesGehalt = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Eintrittsdatum eingeben: ");
                DateTime neuesEintrittsdatum = Convert.ToDateTime(Console.ReadLine());

                Mitarbeiter neuer = new Mitarbeiter(0, neueVorname, neueNachname, neueAbteilung, neuesGehalt, neuesEintrittsdatum);

                repo.Add(neuer);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Mitarbeiter Hinzugefügt");                 

            }

            catch (FormatException)

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe!");
                Console.ResetColor();
                
            }

            finally 
            
            {
                Console.WriteLine("\nDrücken Sie eine Taste...");
                Console.ReadKey(true);

                Console.ResetColor();
            
            }

            break;

        case "4":

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( " == Mitarbeiter bearbeiten == " );
            Console.ResetColor();

            try

            {
               
                Console.Write("MitarbeiterID Eingeben: ");
                int mitarbeiterID = Convert.ToInt32(Console.ReadLine());
              
                Console.Write("Vorname ändern: ");
                string updateVorname = Console.ReadLine();

                Console.Write("Nachname ändern: ");
                string updateNachname = Console.ReadLine();

                Console.Write("AbteilungID ändern: ");
                int updateAbteilung = Convert.ToInt32(Console.ReadLine());

                Console.Write("Gehalt ändern: ");
                decimal updateGehalt = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Eintrittsdatum ändern: ");
                DateTime updateEintrittsdatum = Convert.ToDateTime(Console.ReadLine());

                Mitarbeiter update = new Mitarbeiter(mitarbeiterID, updateVorname, updateNachname, updateAbteilung, updateGehalt, updateEintrittsdatum);

                repo.Update(update);

                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Änderung abgeschlossen");

            }

            catch (FormatException) 
            
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe!");
                    
            }

            finally 
            
            {
                Console.WriteLine("\nDrücken Sie eine Taste...");
                Console.ReadKey(true);

                Console.ResetColor();
            
            }

            break;

        case "5":

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" == Mitarbeiter löschen == ");
            Console.ResetColor();

            try
            {
                Console.Write("Mitarbeiter ID eingeben: ");
                int deleteID = Convert.ToInt32(Console.ReadLine());

                int result = repo.Delete(deleteID);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Mitarbeiter gelöscht");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kein Mitarbeiter mit dieser ID gefunden");
                }

            }

            catch (FormatException)

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe!");
            }

          

            finally

            {
                Console.WriteLine("\nDrücken Sie eine Taste...");
                Console.ReadKey(true);

                Console.ResetColor();
            }

            break;

        case "6":

            Console.WriteLine("== Statistiken anzeigen ==");

            string statSql = "SELECT COUNT(*) AS Anzahl, AVG(Gehalt) AS Durchschnitt, MAX(Gehalt) AS Maximum, MIN(Gehalt) AS Minimum FROM Mitarbeiter ";
            SqlCommand statCommand = new SqlCommand (statSql, connection);

            SqlDataReader reader3 = statCommand.ExecuteReader ();

            while (reader3.Read())
            {

                Console.WriteLine($"Anzahl Mitarbeiter: {reader3["Anzahl"]} - Gehalt Durchschnitt:  {Convert.ToDecimal(reader3["Durchschnitt"]):F2} - Maximum Gehalt: {reader3["Maximum"]} - Minimum Gehalt: {reader3["Minimum"]} ");
            }
            reader3.Close();

            string statSql2 = "SELECT a.Name, COUNT(*) AS Anzahl FROM Mitarbeiter m INNER JOIN Abteilung a ON m.AbteilungID = a.AbteilungID GROUP BY a.Name ";
            SqlCommand statCommand2 = new SqlCommand(statSql2, connection);

            SqlDataReader reader4 = statCommand2.ExecuteReader();

            while (reader4.Read())
            {

                Console.WriteLine($"{reader4["Name"]} - {reader4["Anzahl"]}");
            }
            reader4.Close();

            Console.WriteLine("\nDrücken Sie eine Taste...");
            Console.ReadKey(true);

            break;

        case "7":
            weiter = false;
            break;
    }
}

connection.Close();