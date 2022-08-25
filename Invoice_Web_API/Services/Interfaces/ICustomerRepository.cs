using Invoice_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Web_API.Services.Interfaces
{
    public interface ICustomerRepository
    {
        JsonResult GetCustomers();
        JsonResult GetCustomer(int id);
        JsonResult InsertCustomer(Customer customer);
        JsonResult UpdateCustomer(Customer customer);
        JsonResult DeleteCustomer(int id);
    }
}
