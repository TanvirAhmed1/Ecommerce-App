using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerManager _customerManager;
        IMapper _mapper;
        public CustomersController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCustomers([FromQuery]CustomerRequestModel customer)
        {
            var result = _customerManager.GetByRequest(customer);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than Zero");
            }
            var customer = _customerManager.GetById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult CustomerCreate([FromBody] CustomerCreateDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var customerIntity = _mapper.Map<Customer>(customerDTO);
                bool isSaved = _customerManager.Add(customerIntity);
                if (isSaved)
                {
                    customerDTO.Id = customerIntity.Id;
                    return Ok(customerDTO);
                }
                else
                {
                    return BadRequest("Customer Could Not Be Saved");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
