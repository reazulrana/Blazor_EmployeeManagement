﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
  public  class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }


    }
}
