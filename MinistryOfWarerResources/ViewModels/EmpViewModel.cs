﻿using MinistryOfWarerResources.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinistryOfWarerResources.ViewModels
{
    public class EmpViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "Please provide no more than 60 chars")]

        public string EmpFullName { get; set; }
        [Required]
        [MaxLength(14, ErrorMessage = "please provide no more than 14 chars")]
        [MinLength(14, ErrorMessage = "please provide no less than 14 chars")]
        public string EmpNumber { get; set; }
        [Required]
        [Range(16, 60, ErrorMessage = "Age should between 16-60")]
        public int EmpAge { get; set; }

        public int EmpDep { get; set; }
        public int OfficeId { get; set; }


        [Required]
        [Range(150000, 7000000, ErrorMessage = "Salary should be between 150000-7000000")]
        public decimal EmpSalary { get; set; }
        [Required]
        public string EmploymentStatus { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime DateOfEmployemnt { get; set; }
        public string? EmpImagePath { get; set; }


    }
}
