using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datasql.Models
{
   public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "character varying(250)")]
        public string EmployeeName { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string Department { get; set; }

        [Column(TypeName = "character varying(50)")]
        public string DateOfJoining { get; set; }
    }
}
