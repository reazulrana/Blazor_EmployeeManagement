using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.CustomValidations
{
    public class EmailDomainValidator:ValidationAttribute
    {
        public string AllowDomainName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            int index = ((string)value).IndexOf("@");

            if (index == -1) 
            { 
                return null;

            }

            List<string> values =value.ToString().Split('@').ToList();

            if (AllowDomainName == null)
            {
                return null;
            }
      

            if (values[1].ToString().ToLower() == AllowDomainName.ToLower())
            {
                return null;
            }
            else
            {
                return new ValidationResult($"Domain must be {AllowDomainName}", 
                    new[] { validationContext.MemberName });

            }

        }
      
    }
}
