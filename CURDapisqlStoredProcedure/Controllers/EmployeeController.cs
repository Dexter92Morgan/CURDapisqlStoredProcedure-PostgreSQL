using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datasql;
using System.Data;
using Datasql.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CURDapisqlStoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        db dbop = new db();

        string msg = string.Empty;

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
           // emp.type = "get";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    Department = dr["Department"].ToString(),
                    DateOfJoining = dr["DateOfJoining"].ToString(),
                });;


            }

            return list;

        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<Employee> Get(int id)
        {
            Employee emp = new Employee();
            // emp.type = "get";
            emp.EmployeeId = id;
            DataSet ds = dbop.EmployeeGetId(emp, out msg);
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


        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {

                msg = dbop.EmployeeOpt(emp);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")] 
        public string Put( int id, [FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.EmployeeId = id;
                msg = dbop.Employeeupdate(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Employee emp = new Employee();
                emp.EmployeeId = id;
                msg = dbop.Employeedelete(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
