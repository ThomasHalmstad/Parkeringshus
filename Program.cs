using Microsoft.Data.SqlClient;
using System;
using System.Threading;
using static System.Console;


namespace Parkeringshus
{
    class Program
    {
        static string connectionString = "Data Source=.;Initial Catalog=Parkeringshus;Integrated Security=true;";

        static void Main(string[] args)
        {

            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                WriteLine("1. Register arrival");
                WriteLine("2. Register departure");
                WriteLine("3. Show parking registry");
                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {

                            Write("Customer: ");

                            string customer = ReadLine();

                            Write("Contact details: ");

                            string contactDetails = ReadLine();

                            Write("Registration number: ");

                            string registrationNumber = ReadLine();

                            Write("Description: ");

                            string description = ReadLine();

                            DateTime arrival = DateTime.Now;

                            string query = @"INSERT INTO Parking (Customer,
                                                             ContactDetails,
                                                             RegistrationNumber,
                                                             Description,
                                                             Arrival)
                                         VALUES (@Customer,
                                                 @ContactDetails,
                                                 @RegistrationNumber,
                                                 @Description,
                                                 @Arrival)";


                            SqlConnection connection = new SqlConnection(connectionString);
                            SqlCommand command = new SqlCommand(query, connection);

                            command.Parameters.AddWithValue("@Customer", customer);
                            command.Parameters.AddWithValue("@ContactDetails", contactDetails);
                            command.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);
                            command.Parameters.AddWithValue("@Description", description);
                            command.Parameters.AddWithValue("@Arrival", arrival);

                            connection.Open();

                            command.ExecuteNonQuery();

                            connection.Close();

                            Clear();

                            WriteLine("Parking registered.");

                            Thread.Sleep(2000);

                            break;
                        }

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {

                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            WriteLine("ID   Registration number         Arrival      Departure");
                            WriteLine("------------------------------------------------------------");

                            string query = @"SELECT	Id, 
		                                    Customer,
		                                    ContactDetails,
		                                    RegistrationNumber,
		                                    Description,
		                                    Arrival,
		                                    Departure
	                                    FROM Parking;";

                            SqlConnection connection = new SqlConnection(connectionString);

                            SqlCommand command = new SqlCommand(query, connection);

                            connection.Open();

                            SqlDataReader dataReader = command.ExecuteReader();

                            while (dataReader.Read())
                            {
                                string id = dataReader["Id"].ToString();
                                string registrationNumber = dataReader["RegistrationNumber"].ToString();
                                string arrival = dataReader["Arrival"].ToString();
                                string departure = dataReader["Departure"].ToString();


                                Write(id.PadRight(5, ' '));
                                Write(registrationNumber.PadRight(20, ' '));
                                Write(arrival.PadRight(20, ' '));
                                WriteLine(departure);

                            }

                            connection.Close();
                            WriteLine();
                            WriteLine("Press key to continue");

                            ReadKey(true);




                        break;

                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        shouldNotExit = false;

                        break;
                
                }

                Clear();

            }

        }
    }
}
