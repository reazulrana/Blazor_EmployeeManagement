
using System;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Model;
using EmployeeManagement.Model.CustomValidations;

namespace EmployeeManagement.Web.Model
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowDomainName = "gmail.com")]
        public string Email { get; set; }
        [Required]
        [Compare("Email",ErrorMessage ="Confirm Email Not Matched")]
        public string ConfirmEmail { get; set; }
        public DateTime DateofBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
