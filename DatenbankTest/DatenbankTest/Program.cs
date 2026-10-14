using Microsoft.Data.SqlClient;

string connectionString = "Server=localhost\\SQLEXPRESS;Database=Formation;Trusted_Connection=True;TrustServerCertificate=True;";

SqlConnection connection = new SqlConnection(connectionString);

try
{
    connection.Open();
    Console.WriteLine("Verbindung erfolgreich!");

    string sql = "SELECT * FROM Artikel";
    SqlCommand command = new SqlCommand(sql, connection);
    SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"{reader["ArtikelID"]} - {reader["Name"]} - {reader["Preis"]}€ - Lager: {reader["Lagerbestand"]}");
    }

    reader.Close();
}
catch (Exception e)
{
    Console.WriteLine($"Fehler: {e.Message}");
}
finally
{
    connection.Close();
    Console.WriteLine("Verbindung geschlossen.");
}