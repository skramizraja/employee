using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sample.EmployeeDTO;
using sample.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeServices _subSvc;



        public EmployeeController(EmployeeServices submissionService)
        {
            _subSvc = submissionService;

        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<EmployeeMember>> GetAllEmployee()
        {
            var employees = _subSvc.GetAllEmployees();

            var result = employees;
            // var result = mapper.Map<List<EmployeeMember>, IEnumerable<EmployeeViewModel>>(await employees);
            return await result;

        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        [EnableCors("AllowOrigin")]
        public async Task<EmployeeMember> GetEmployeeById(string id)
        {
            var foundEmployee = await _subSvc.GetEmployeeById(id);
            if (foundEmployee == null)
            {
                //return BadRequest();
            }
            return foundEmployee;
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> CreateEmployeeRecord(EmployeeMember newEmployeeDetails)
        {
            if (!ModelState.IsValid)
            {
                // return BadRequest();
            }
            var isCreated = await _subSvc.CreateEmployeeRecord(newEmployeeDetails);

            if (isCreated == false)
            {
                //return BadRequest();
            }
            return Ok();
        }


        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> UpdateEmployee(string id, EmployeeMember employee)
        {
            var isUpdated = await _subSvc.UpdateEmployeeRecord(id, employee);
            if (isUpdated == false)
            {
                return BadRequest();
            }
            return Ok();
        }



        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            var isDeleted = await _subSvc.DeleteEmployeeRecord(id);
            if (isDeleted == false)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpGet("FirstName", Name = "GetEmployeeByFirstName")]
        [EnableCors("AllowOrigin")]
        public async Task<EmployeeMember> GetEmployeeByFirstName(string name)
        {
            var foundEmployee = await _subSvc.GetEmployeeByFirstName(name);
            if (foundEmployee == null)
            {
                //return BadRequest();
            }
            return foundEmployee;
        }



















    }
}
