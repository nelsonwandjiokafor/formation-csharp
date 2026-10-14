using Microsoft.Data.SqlClient;

string connectionString = "Server=localhost\\SQLEXPRESS;Database=Formation;Trusted_Connection=True;TrustServerCertificate=True;";
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

bool weiter = true;

while (weiter)
{
    Console.WriteLine("\n=== MITARBEITERVERWALTUNG ===");
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
         
            string sql = "SELECT Vorname, Nachname, Name AS Abteilung, Gehalt FROM Mitarbeiter INNER JOIN Abteilung ON Mitarbeiter.AbteilungID = Abteilung.AbteilungID";
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader(); 
            while (reader.Read()) 
            
            {
                Console.WriteLine($" {reader["Vorname"]} - {reader["Nachname"]} - {reader["Abteilung"]} - {reader["Gehalt"]} Euro");

            }           
             reader.Close();

            break;

        case "2":
            Console.WriteLine("== Mitarbeiter suchen ==");

            Console.Write("Vorname eingeben: ");
            string vorname = Console.ReadLine();

            string sqlSuche = $"SELECT Vorname, Nachname FROM Mitarbeiter WHERE Vorname LIKE '%{vorname}%'";
            SqlCommand commandSuche = new SqlCommand(sqlSuche, connection);

            SqlDataReader reader2 = commandSuche.ExecuteReader();

            while(reader2.Read()) 
            
            {

                Console.WriteLine($"{reader2["Vorname"]} - {reader2["Nachname"]}");

            }
            reader2.Close();

            break;

        case "3":

            Console.WriteLine("== Neuen Mitarbeiter hinzufügen ==");

            Console.Write("Vorname eingeben: ");
            string neueVorname = Console.ReadLine();

            Console.Write("Nachname eingeben: ");
            string neueNachname= Console.ReadLine();

            Console.Write("AbteilungID eingeben: ");
            int neueAbteilung= Convert.ToInt32(Console.ReadLine());

            Console.Write("Gehalt eingeben: ");
            decimal neuesGehalt = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Eintrittsdatun eingeben: ");
            DateTime neuesEintrittsdatum = Convert.ToDateTime(Console.ReadLine());

            string sqlHinzufugen = $"INSERT INTO Mitarbeiter (Vorname, Nachname, AbteilungID, Gehalt, Eintrittsdatum) VALUES ('{neueVorname}','{neueNachname}', {neueAbteilung} ,{neuesGehalt},'{neuesEintrittsdatum}')";
            SqlCommand commandHinzufugen = new SqlCommand(sqlHinzufugen, connection);

            commandHinzufugen.ExecuteNonQuery();

            Console.WriteLine("Mitarbeiter Hinzugefügt");

            break;

        case "4":

            Console.WriteLine( " == Mitarbeiter bearbeiten == " );

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

            Console.Write("Eintrittsdatun ändern: ");
            DateTime updateEintrittsdatum = Convert.ToDateTime(Console.ReadLine());

            string sqlUpdate = $" UPDATE Mitarbeiter  SET Vorname = '{updateVorname}', Nachname = '{updateNachname}', AbteilungID = {updateAbteilung}, Gehalt = {updateGehalt}, Eintrittsdatum = '{updateEintrittsdatum}' WHERE MitarbeiterID = {mitarbeiterID}";
            SqlCommand updateCommand = new SqlCommand (sqlUpdate, connection);

            updateCommand.ExecuteNonQuery();

            Console.WriteLine("Änderung abgeschlossen");

            break;

        case "5":

            Console.WriteLine(" == Mitarbeiter löschen == ");

            Console.Write("Mitarbeiter Vorname eingeben: ");
            string deleteVorname = Console.ReadLine();


            string deleteSql = $"DELETE FROM Mitarbeiter WHERE Vorname = '{deleteVorname}'";
            SqlCommand deleteCommand = new SqlCommand (deleteSql, connection);

            deleteCommand.ExecuteNonQuery();

            Console.WriteLine("Mitarbeiter wurde gelöscht");

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


            break;

        case "7":
            weiter = false;
            break;
    }
}

connection.Close();