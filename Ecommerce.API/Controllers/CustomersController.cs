using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name ="GetById")]
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
                    return CreatedAtRoute("GetById", new {id=customerDTO.Id }, customerDTO);
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
        public IActionResult PutCustomer(int id,[FromBody] CustomerUpdateDTO CustomerDTO)
        {
            try
            {
                var existingCustomer = _customerManager.GetById(id);
                if (existingCustomer == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var customer = _mapper.Map(CustomerDTO, existingCustomer);
                
                bool IsUpdated = _customerManager.Update(customer);
                if (IsUpdated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Update Failed!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("System Error Occured!");
            }
            

        }
        public IActionResult PatchCustomer(int id, [FromBody] JsonPatchDocument<CustomerUpdateDTO> patchDoc)
        {
            var existingCustomer = _customerManager.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerUpdateDTO>(existingCustomer);
            patchDoc.ApplyTo(customerDto);
            _mapper.Map(customerDto, existingCustomer);
            bool IsUpdated = _customerManager.Update(existingCustomer);
            if (IsUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Update Failed!");
            }
        }
        
    }
}
