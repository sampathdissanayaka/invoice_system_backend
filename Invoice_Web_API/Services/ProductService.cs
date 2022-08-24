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
    public class ProductService : IProductRepository
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JsonResult GetProducts()
        {
            string query = @"select Id, ProductName, ProductPrice from dbo.Products";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("InvoiceAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                        
                }
            }

            return new JsonResult(table);
        }
    }
}
