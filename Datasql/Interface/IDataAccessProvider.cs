using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Datasql.Models;

namespace Datasql.Interface
{
    public interface IDataAccessProvider
    {
        void AddEmployeeRecord(Employee employee);
        void UpdateEmployeeRecord(Employee employee);
        void DeleteEmployeeRecord(int id);
        Employee GetEmployeeSingleRecord(int id);
        DataSet EmployeeGet(Employee emp, out string msg);

    }
}
