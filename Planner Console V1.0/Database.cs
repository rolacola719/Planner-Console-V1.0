using Planner_Console_V1._0.UIManager;
using System.Data.SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Planner_Console_V1._0
{

    internal class Database
    {
        public static void CreateAppointment()
        {
            UI.CreateAppointment(out string subject, out DateTime startDate, out DateTime endDate);


            string connectionString = "Data Source=appointments.db;Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Appointments (Title, Start, End) VALUES (@Title, @Start, @End)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", subject);
                    command.Parameters.AddWithValue("@Start", startDate);
                    command.Parameters.AddWithValue("@End", endDate);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Appointment added successfully.");
            }
        }

        public static List<Appointment> ReturnAppointments()
        {
            string connectionString = "Data Source=appointments.db;Version=3;";
            List<Appointment> appointments = new List<Appointment>();

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Appointments ORDER BY Start ASC";

                    using (var command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map the database columns to the Appointment object properties
                                appointments.Add(new Appointment
                                {
                                    Id = reader.GetInt32(0),          // Assuming the first column is the Id
                                    Title = reader.GetString(1),     // Assuming the second column is Title
                                    Start = reader.GetDateTime(2),   // Assuming the third column is Start
                                    End = reader.GetDateTime(3)      // Assuming the fourth column is End
                                });
                            }
                        }
                    }
                }

                return appointments;
            }
        
        public static void DeleteAppointment()
        {
            while (true)
            {
                Output.DeleteOptionDialog();
                string option = Input.GetReadLine();

                string connectionString = "Data Source=appointments.db;Version=3;";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Appointments WHERE Id = @Id";

                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        // Use parameterized query to prevent SQL injection
                        command.Parameters.AddWithValue("@Id", option);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Appointment with Id {option} has been deleted.");
                        }
                        else
                        {
                            Console.WriteLine($"No appointment found with Id {option}.");
                        }
                    }
                }
            }
        }
    }
}
