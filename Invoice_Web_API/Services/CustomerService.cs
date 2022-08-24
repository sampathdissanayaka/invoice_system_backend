using Invoice_Web_API.Models;
using Invoice_Web_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Web_API.Services
{
    public class CustomerService : ICustomerRepository
    {
        private readonly IConfiguration _configuration;
        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JsonResult DeleteCustomer(int id)
        {
            string query = @"delete from dbo.Customers where Id=@Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("InvoiceAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        public JsonResult GetCustomers()
        {
            string query = @"select Id, CustomerName, TransactionDate, ProductId, ProductQualityId, Discount, TotalAmount from dbo.Customers";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("InvoiceAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        public JsonResult InsertCustomer(Customer customer)
        {
            string query = @"insert into dbo.Customers values (@CustomerName, @TransactionDate, @ProductId, @ProductQualityId, @Discount, @TotalAmount)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("InvoiceAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    myCommand.Parameters.AddWithValue("@TransactionDate", customer.TransactionDate);
                    myCommand.Parameters.AddWithValue("@ProductId", customer.ProductId);
                    myCommand.Parameters.AddWithValue("@ProductQualityId", customer.ProductQualityId);
                    myCommand.Parameters.AddWithValue("@Discount", customer.Discount);
                    myCommand.Parameters.AddWithValue("@TotalAmount", customer.TotalAmount);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        public JsonResult UpdateCustomer(Customer customer)
        {
            string query = @"update dbo.Customers set CustomerName= @CustomerName, TransactionDate= @TransactionDate, ProductId= @ProductId, ProductQualityId= @ProductQualityId, Discount= @Discount, TotalAmount= @TotalAmount  where Id=@Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("InvoiceAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", customer.Id);
                    myCommand.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    myCommand.Parameters.AddWithValue("@TransactionDate", customer.TransactionDate);
                    myCommand.Parameters.AddWithValue("@ProductId", customer.ProductId);
                    myCommand.Parameters.AddWithValue("@ProductQualityId", customer.ProductQualityId);
                    myCommand.Parameters.AddWithValue("@Discount", customer.Discount);
                    myCommand.Parameters.AddWithValue("@TotalAmount", customer.TotalAmount);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
    }
}
