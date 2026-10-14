using Microsoft.Data.SqlClient;

string connectionString = "Server=localhost\\SQLEXPRESS;Database=Formation;Trusted_Connection=True;TrustServerCertificate=True;";
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

bool weiter = true;

while (weiter)
{
    Console.WriteLine("\n=== ARTIKEL VERWALTUNG ===");
    Console.WriteLine("1. Alle Artikel anzeigen");
    Console.WriteLine("2. Neuen Artikel hinzufügen");
    Console.WriteLine("3. Preis ändern");
    Console.WriteLine("4. Artikel löschen");
    Console.WriteLine("5. Beenden");
    Console.Write("Auswahl: ");

    string auswahl = Console.ReadLine();

    switch (auswahl)
    {
        case "1":
            //SELECT * FROM Artikel → ExecuteReader → while reader.Read()
            string sql = "SELECT * FROM Artikel";
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                Console.WriteLine($"{reader["Name"]} - {reader["Preis"]} - {reader["Lagerbestand"]}");
            }
            reader.Close();

            break;

        case "2":
            // Demander Name, Preis, Lagerbestand
            // INSERT INTO Artikel → ExecuteNonQuery
            Console.WriteLine(" == Neuen Artikel hinzufügen == ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Preis: ");
            double preis = Convert.ToDouble(Console.ReadLine());

            Console.Write("Lagerbestand: ");
            int lagerbestand = Convert.ToInt32(Console.ReadLine());

            string insertSql = $"INSERT INTO Artikel (Name , Preis, Lagerbestand) VALUES ('{name}', {preis}, {lagerbestand})";
            SqlCommand insertCommand = new SqlCommand(insertSql, connection);
            insertCommand.ExecuteNonQuery();

            Console.WriteLine("Artikel wurde hinzugefügt");

            break;

        case "3":
            // Demander ArtikelID et neuer Preis
            // UPDATE Artikel SET Preis = ... WHERE ArtikelID = ...

            Console.WriteLine(" == Preis ändern == ");

            Console.Write("ArtikelID: ");
            int artikelId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Neue Preis eingeben:");
            double neuePreis = Convert.ToDouble(Console.ReadLine());

            string updatePreis = $"UPDATE Artikel SET Preis = {neuePreis}  WHERE ArtikelID = {artikelId}";
            SqlCommand updateCommand = new SqlCommand(updatePreis, connection);

            updateCommand.ExecuteNonQuery();

            Console.WriteLine("Preis wurde geändert");

            break;

        case "4":
            // Demander ArtikelID
            // DELETE FROM Artikel WHERE ArtikelID = ...
            Console.WriteLine(" == Artikel löschen ==");

            Console.Write("ArtikelID: ");
            int artikelId2 = Convert.ToInt32(Console.ReadLine());

            string deleteArtikel = $"DELETE FROM  Artikel WHERE ArtikelID = {artikelId2} ";
            SqlCommand deleteCommand = new SqlCommand(deleteArtikel, connection);

            deleteCommand.ExecuteNonQuery();

            Console.WriteLine("Artikel wurde gelöscht");


            break;

        case "5":
            weiter = false;
            break;
    }
}

connection.Close();
Console.WriteLine("Verbindung geschlossen.");