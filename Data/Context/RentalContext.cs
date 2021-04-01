using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Rental.Data.Context
{
    public class RentalContext
    {
        private MySqlConnection GetConnection()
        {
            return new("Database=Temporal;Data Source=localhost;User Id=root;Password=HDgtDVi5");
        }

        public async Task<List<Car>> GetAllCars()
        {
            var cars = new List<Car>();
            var adapter = new MySqlDataAdapter("Select * from Car", GetConnection());
            var table = new DataTable();
            
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                cars.Add(new Car
                {
                    License = row["CAR_LICENSE"].ToString(),
                    Image = row["CAR_IMAGE"].ToString(),
                    Copyright = row["CAR_COPYRIGHT"].ToString()
                });
            }
            
            return await Task.FromResult(cars);
        }
    }
}