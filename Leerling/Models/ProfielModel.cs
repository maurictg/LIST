using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LIST.Areas.Leerling.Models
{
    public class ProfielModel
    {
        public bool UpdateKeuze(Profiel profiel, string token)
        {
            token = token.Remove(0, 1);
            string keuze = profiel.lijn;

            SqlConnection connection = new SqlConnection(LIST.Classes.Engine.connectionstring());
            SqlCommand command = new SqlCommand("UPDATE Profielkeuze SET keuzelijn=@keuzelijn WHERE token=@token", connection);
            command.Parameters.AddWithValue("@keuzelijn", keuze);
            command.Parameters.AddWithValue("@token", token);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                LIST.Classes.Engine.WriteError(ex.ToString(), "geen");
                connection.Close();
                return false;
            }

        }



        public Profiel profielOphalen(string token)
        {
            Profiel prof = new Profiel();

            try
            {
                token = token.Remove(0, 1);
                SqlConnection connection = new SqlConnection(LIST.Classes.Engine.connectionstring());
                SqlCommand command = new SqlCommand("SELECT * FROM Profielkeuze WHERE token=@token", connection);
                command.Parameters.AddWithValue("@token", token);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(reader["definitief"].ToString() == "1")
                    {
                        prof.gekozen = true;
                    }
                    else
                    {
                        prof.gekozen = false;
                    }
                    if(reader["keuzelijn"] == null)
                    {
                        prof.lijn = "Geen gekozen";
                    }
                    else
                    {
                        prof.lijn = reader["keuzelijn"].ToString();
                    }
                }
                connection.Close();

                return prof;
            }
            catch
            {
                return null;
            }
        }
    }
}