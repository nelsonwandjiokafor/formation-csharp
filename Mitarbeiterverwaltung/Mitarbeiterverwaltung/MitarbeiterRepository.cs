using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mitarbeiterverwaltung
{
    internal class MitarbeiterRepository
    {
        private SqlConnection connection;

        public MitarbeiterRepository(SqlConnection conn)
        {
            connection = conn;
        }

        public List<Mitarbeiter> GetAll()
        {
            List<Mitarbeiter> liste = new List<Mitarbeiter>();

            string sql = "SELECT MitarbeiterID, Vorname, Nachname, m.AbteilungID, Gehalt, Eintrittsdatum FROM Mitarbeiter m INNER JOIN Abteilung a ON m.AbteilungID = a.AbteilungID";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Mitarbeiter m = new Mitarbeiter(
                    Convert.ToInt32(reader["MitarbeiterID"]),
                    reader["Vorname"].ToString(),
                    reader["Nachname"].ToString(),
                    Convert.ToInt32(reader["AbteilungID"]),
                    Convert.ToDecimal(reader["Gehalt"]),
                    Convert.ToDateTime(reader["Eintrittsdatum"])
                );
                liste.Add(m);
            }
            reader.Close();

            return liste;
        }

            public void Add(Mitarbeiter m)

        {
            string sql = $"INSERT INTO Mitarbeiter (Vorname, Nachname, AbteilungID, Gehalt, Eintrittsdatum) VALUES ('{m.Vorname}','{m.Nachname}', {m.AbteilungID}, {m.Gehalt}, '{m.Eintrittsdatum}')";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

        }

            public void Update(Mitarbeiter m)
        {
     
            string sqlUpdate = $"UPDATE Mitarbeiter SET Vorname = '{m.Vorname}', Nachname = '{m.Nachname}', AbteilungID = {m.AbteilungID}, Gehalt = {m.Gehalt}, Eintrittsdatum = '{m.Eintrittsdatum}' WHERE MitarbeiterID = {m.MitarbeiterID} ";
            SqlCommand commandUpdate = new SqlCommand(sqlUpdate, connection);

            commandUpdate.ExecuteNonQuery();

        }

        public int Delete(int id)

        {

            string sqlDelete = $"DELETE FROM Mitarbeiter WHERE MitarbeiterID = {id}";

            SqlCommand commandDelete = new SqlCommand(sqlDelete, connection);

            return commandDelete.ExecuteNonQuery();
                
        }

    }

}
    
    







