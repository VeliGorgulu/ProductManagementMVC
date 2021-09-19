using ProductManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductManagementMVC.DataAccess
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public void Add(Product entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddProduct";
            command.Connection = _connection;

            command.Parameters.AddWithValue("@ProductName", entity.ProductName);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@Stock", entity.Stock);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Product entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateProduct";
            command.Connection = _connection;

            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@ProductName", entity.ProductName);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@Stock", entity.Stock);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(Product entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteProduct";
            command.Connection = _connection;

            command.Parameters.AddWithValue("@Id", entity.Id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
        public Product Get(int id)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetProduct";

            command.Parameters.AddWithValue("@Id", id);

            command.Connection = _connection;

            SqlDataReader reader = command.ExecuteReader();


            Product product = null;

            while (reader.Read())
            {
                product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductName = reader["ProductName"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Stock = Convert.ToInt32(reader["Stock"]),
                };
            }

            reader.Close();
            _connection.Close();

            return product;
        }

        public List<Product> GetAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAllProducts";


            command.Connection = _connection;


            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductName = reader["ProductName"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Stock = Convert.ToInt32(reader["Stock"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}