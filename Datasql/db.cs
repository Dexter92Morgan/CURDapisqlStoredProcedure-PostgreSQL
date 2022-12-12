using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using Datasql.Models;
using System.Data;

namespace Datasql
{
    public class db
    {


        NpgsqlConnection myCon = new NpgsqlConnection("Host=localhost;Port=5432;User ID=postgres; Password=password;Database=new;Pooling=true;");

        // POST record
        public string EmployeeOpt(Employee emp)
        {
            string query = @"
                insert into Employees (EmployeeName,Department,DateOfJoining)
                values (@EmployeeName,@Department,@DateOfJoining) ";

            string msg = string.Empty;
            try
            {
                NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                myCommand.Parameters.AddWithValue("@Department", emp.Department);
                myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);

                myCon.Open();
                myCommand.ExecuteNonQuery();
                myCon.Close();
                msg = "SUCCESS";

            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {

                 if(myCon.State == ConnectionState.Open)
                {
                    myCon.Close();

                }
            }
            return msg;
        }

        // GET record
        public DataSet EmployeeGet(Employee emp, out string msg)
        {
            string query = @"
                select EmployeeId as ""EmployeeId"",EmployeeName as ""EmployeeName"", Department as ""Department"",DateOfJoining as ""DateOfJoining""
                   from Employees ";

            msg = string.Empty;
            DataSet ds = new DataSet();
            try
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
            catch (Exception ex)
            {
                msg = ex.Message;
            }
              return ds;
        }

        // GET record ID
        public DataSet EmployeeGetId(Employee emp, out string msg)
        {
            string query = @"
                select EmployeeId as ""EmployeeId"",EmployeeName as ""EmployeeName"", Department as ""Department"",DateOfJoining as ""DateOfJoining""
                   from Employees where EmployeeId = @EmployeeId ";

            msg = string.Empty;
            DataSet ds = new DataSet();
            try
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
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }


        // Update record ID
        public string Employeeupdate(Employee emp)
        {

            string query = @"
                update Employees
                set EmployeeName = @EmployeeName, Department = @Department, DateOfJoining = @DateOfJoining
                where EmployeeId=@EmployeeId ";

            string msg = string.Empty;

            try
            {
                NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon);
                myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                myCommand.Parameters.AddWithValue("@Department", emp.Department);
                myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);

                myCon.Open();
                myCommand.ExecuteNonQuery();
                myCon.Close();
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {

                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();

                }
            }
            return msg;
        }


        // Delete record ID
        public string Employeedelete(Employee emp)
        {

            string query = @"
                delete from Employees
                where EmployeeId=@EmployeeId ";

            string msg = string.Empty;

            try
            {
                NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon);

                myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                myCommand.Parameters.AddWithValue("@Department", emp.Department);
                myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);

                myCon.Open();
                myCommand.ExecuteNonQuery();
                myCon.Close();
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {

                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();

                }
            }
            return msg;
        }

    }
}
