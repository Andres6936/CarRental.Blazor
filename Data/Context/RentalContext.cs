using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Rental.Data.Context
{
    public class RentalContext
    {

        private static MySqlConnection _connection;
        
        private MySqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection =
                    new MySqlConnection("Database=Temporal;Data Source=localhost;User Id=root;Password=HDgtDVi5");
                return _connection;
            }

            return _connection;
        }

        private Car GetCarFromRow(DataRow row)
        {
            return new()
            {
                Name = row["CAR_NAME"].ToString(),
                Image = row["CAR_IMAGE"].ToString(),
                License = row["CAR_LICENSE"].ToString(),
                Copyright = row["CAR_COPYRIGHT"].ToString(),
                Transmission = row["CAR_TRANSMISSION"].ToString(),
                AirConditioning = row["CAR_AIR"].ToString(),
                Own = int.Parse(row["CAR_OWN"].ToString()),
                Bags = int.Parse(row["CAR_BAGS"].ToString()),
                Doors = int.Parse(row["CAR_DOORS"].ToString()),
                Price = int.Parse(row["CAR_PRICE_PER_DAY"].ToString()),
                People = int.Parse(row["CAR_PEOPLE"].ToString()),
            };
        }

        private Loan GetLoanFromRow(DataRow row)
        {
            return new()
            {
                Serial = int.Parse(row["LOAN_SERIAL"].ToString()),
                User = row["LOAN_USER"].ToString(),
                DateStart = (DateTime) row["LOAN_DATE_START"],
                DateEnd = (DateTime) row["LOAN_DATE_END"],
                CarLicense = row["LOAN_CAR_LICENSE"].ToString(),
                HasBeenCanceled = row["LOAN_HB_CANCELED"].ToString()
            };
        }

        private List<Loan> GetInformationLoanFromQuery(DataTable table)
        {
            var loans = new List<Loan>();

            foreach (DataRow row in table.Rows)
            {
                loans.Add(GetLoanFromRow(row));
            }

            return loans;
        }

        private List<Car> GetInformationCarsFromQuery(DataTable table)
        {
            var cars = new List<Car>();
            
            foreach (DataRow row in table.Rows)
            {
                cars.Add(GetCarFromRow(row));
            }

            return cars;
        }

        public async Task<List<Loan>> GetLoansByLicense(string license)
        {
            var cmd = new MySqlCommand("Select * from Loan Where Loan.LOAN_CAR_LICENSE = @License",
                GetConnection());
            
            // Fill the parameters
            cmd.Parameters.AddWithValue("@License", license);
            
            var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();
            
            adapter.Fill(table);

            return await Task.FromResult(GetInformationLoanFromQuery(table));
        }
        
        public async Task<List<Loan>> GetLoansByUser(string user)
        {
            var cmd = new MySqlCommand("Select * from Loan Where Loan.LOAN_USER = @User",
                GetConnection());
            
            // Fill the parameters
            cmd.Parameters.AddWithValue("@User", user);
            
            var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();
            
            adapter.Fill(table);

            return await Task.FromResult(GetInformationLoanFromQuery(table));
        }
        
        public async Task<Car> GetCarByLicense(string license)
        {
            var cmd = new MySqlCommand("Select * from Car where CAR_LICENSE = @License",
                GetConnection());
            
            // Fill the parameters
            cmd.Parameters.AddWithValue("@License", license);
            
            var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();
            
            adapter.Fill(table);

            // Get the first and unique result
            DataRow row = table.Rows[0];

            return await Task.FromResult(GetCarFromRow(row));
        }

        public async Task<List<Loan>> GetAllLoans()
        {
            var adapter = new MySqlDataAdapter("Select * from Loan", GetConnection());
            var table = new DataTable();
            
            adapter.Fill(table);

            return await Task.FromResult(GetInformationLoanFromQuery(table));
        }
        
        public async Task<List<Car>> GetAllCars()
        {
            var adapter = new MySqlDataAdapter("Select * from Car", GetConnection());
            var table = new DataTable();
            
            adapter.Fill(table);

            return await Task.FromResult(GetInformationCarsFromQuery(table));
        }

        public async Task<List<Car>> GetAllOwnCars()
        {
            var adapter = new MySqlDataAdapter(
                "Select * from Car where CAR_IS_OWN = 'YES'", GetConnection());
            var table = new DataTable();
            
            adapter.Fill(table);
            
            return await Task.FromResult(GetInformationCarsFromQuery(table));
        }

        /**
         * The aim of this method is fixed the format of dates, the current dates for the loan record
         * had a wrong format, in several records the end date is earlier to start date.
         * <returns>Return 1 if the operation is successful, any other value if the operation fail.</returns>
         */
        public int UpdateLoanDates(int serial, string start, string end)
        {
            var connection = GetConnection(); 
            var cmd = new MySqlCommand("Update Loan Set Loan.LOAN_DATE_START = @DateStart, Loan.LOAN_DATE_END = @DateEnd Where Loan.LOAN_SERIAL = @Serial",
                connection);
            
            // Fill the parameters
            cmd.Parameters.AddWithValue("@Serial", serial);
            cmd.Parameters.AddWithValue("@DateStart", start);
            cmd.Parameters.AddWithValue("@DateEnd", end);
            
            connection.Open();
            
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            
            return result;
        }

        public int UpdateLoanTotalDaysUsed(int serial, int totalDaysUsed)
        {
            var connection = GetConnection(); 
            var cmd = new MySqlCommand("Update Loan Set Loan.LOAN_TOTAL_DAYS_USED = @TotalDaysUsed Where Loan.LOAN_SERIAL = @Serial",
                connection);
            
            // Fill the parameters
            cmd.Parameters.AddWithValue("@Serial", serial);
            cmd.Parameters.AddWithValue("@TotalDaysUsed", totalDaysUsed);

            connection.Open();
            
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            
            return result;
        }

        public bool VerifyUserCredentials(string username, string password)
        {
            var connection = GetConnection(); 
            var cmd = new MySqlCommand("Select exists(select * from User where CLI_USER=@User and CLI_PASSWORD=@Password)",
                connection);
            
            // Fill the parameters
            cmd.Parameters.AddWithValue("@User", username);
            cmd.Parameters.AddWithValue("@Password", password);

            connection.Open();
            
            long number = (long) cmd.ExecuteScalar();
            bool result = number > 0;
            
            Console.WriteLine("(long) cmd.ExecuteScalar() = " + number);
            
            connection.Close();
            
            return result;
        }
    }
}