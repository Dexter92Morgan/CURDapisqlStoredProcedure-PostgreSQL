using System;
using System.Collections.Generic;
using System.Text;
using Datasql.Models;
using Datasql.Interface;
using Datasql.DataAccess;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Datasql.Repository
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly IConfiguration _configuration;
        public DataAccessProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddEmployeeRecord(Employee employee)
        {

            string query = @"
                insert into Employees (EmployeeName,Department,DateOfJoining)
                values (@EmployeeName,@Department,@DateOfJoining) ";


    
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
           
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", employee.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    myCommand.ExecuteNonQuery();

                    myCon.Close();

                }
            }
        }

        public void DeleteEmployeeRecord(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet EmployeeGet(Employee emp, out string msg)
        {

            string query = @"
                select DepartmentId as ""DepartmentId"",DepartmentName as ""DepartmentName""
                   from Department ";

            msg = string.Empty;
            DataSet ds = new DataSet();

            try
            {
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {


                    NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon);
                    myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", emp.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(myCommand);
                    da.Fill(ds);
                    msg = "SUCCESS";

                    return ds;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
       

        }

        public Employee GetEmployeeSingleRecord(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployeeRecord(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
