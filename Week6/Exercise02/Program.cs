using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=Northwind;Trusted_Connection=True;";

        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        // Get all unique cities
        string cityQuery = "SELECT DISTINCT City FROM Customers ORDER BY City";
        using SqlCommand cityCommand = new SqlCommand(cityQuery, connection);
        using SqlDataReader cityReader = cityCommand.ExecuteReader();

        Console.WriteLine("Available cities:");
        while (cityReader.Read())
        {
            Console.Write(cityReader.GetString(0) + ", ");
        }

        cityReader.Close();

        Console.WriteLine(); // New line
        Console.Write("\nEnter the name of a city: ");
        string city = Console.ReadLine();

        // Get companies in selected city
        string customerQuery = "SELECT CompanyName FROM Customers WHERE City = @City";
        using SqlCommand customerCommand = new SqlCommand(customerQuery, connection);
        customerCommand.Parameters.AddWithValue("@City", city);

        using SqlDataReader customerReader = customerCommand.ExecuteReader();

        int count = 0;
        while (customerReader.Read())
        {
            if (count == 0)
                Console.WriteLine($"\nCustomers in {city}:");

            Console.WriteLine(customerReader.GetString(0));
            count++;
        }

        if (count == 0)
        {
            Console.WriteLine($"No customers found in {city}.");
        }
    }
}