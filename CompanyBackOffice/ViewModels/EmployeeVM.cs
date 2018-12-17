using CompanyBackOffice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBackOffice.ViewModels
{
    public class EmployeeVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Seniority { get; set; }

        public static implicit operator EmployeeVM(Employee employee)
        {
            return new EmployeeVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = DateTime.Today.Year - employee.BirthDate.Year,
                Seniority = DateTime.Today.Year - employee.AdmissionDate.Year
            };
        }
    }

    public class CreateEmployeeVM
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("brtDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [JsonProperty("adDate")]
        public DateTime AdmissionDate { get; set; }

        public static explicit operator Employee(CreateEmployeeVM vm)
        {
            return new Employee
            {
                Name = vm.Name,
                BirthDate = vm.BirthDate,
                AdmissionDate = vm.AdmissionDate
            };
        }
    }
}
