using Invoice_Web_API.Models;
using Invoice_Web_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public JsonResult GetCustomers()
        {
            try
            {
                return _customerRepository.GetCustomers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult InsertCustomers(Customer customer)
        {
            try
            {
                return _customerRepository.InsertCustomer(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPut]
        public JsonResult UpdateCustomer(Customer customer)
        {
            try
            {
                return _customerRepository.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteCustomer(int id)
        {
            try
            {
                return _customerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
