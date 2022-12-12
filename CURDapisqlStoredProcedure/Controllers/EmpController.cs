using Datasql.Interface;
using Datasql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datasql.DataAccess;
using Datasql.Repository;
using System.Data;

namespace CURDapisqlStoredProcedure.Controllers
{

    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public EmpController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        string msg = string.Empty;

        [Route("api/Emp")]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            Employee emp = new Employee();
            // emp.type = "get";
            DataSet ds = _dataAccessProvider.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    Department = dr["Department"].ToString(),
                    DateOfJoining = dr["DateOfJoining"].ToString(),
                }); ;


            }

            return list;

        }

        [Route("api/Emp")]
        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid(); if 'id' is string
                //patient.id = obj.ToString();
                _dataAccessProvider.AddEmployeeRecord(employee);
                return Ok();
            }
            return BadRequest();
        }
    }
}
