using System;
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

        private List<Car> GetInformationCarsFromQuery(DataTable table)
        {
            var cars = new List<Car>();
            
            foreach (DataRow row in table.Rows)
            {
                cars.Add(new Car
                {
                    Name = row["CAR_NAME"].ToString(),
                    Image = row["CAR_IMAGE"].ToString(),
                    License = row["CAR_LICENSE"].ToString(),
                    Copyright = row["CAR_COPYRIGHT"].ToString(),
                    Own = int.Parse(row["CAR_OWN"].ToString()),
                    Price = int.Parse(row["CAR_PRICE_PER_DAY"].ToString()),
                });
            }

            return cars;
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
                "Select * from Car where CAR_OWN = 1143995473", GetConnection());
            var table = new DataTable();
            
            adapter.Fill(table);
            
            return await Task.FromResult(GetInformationCarsFromQuery(table));
        }
    }
}