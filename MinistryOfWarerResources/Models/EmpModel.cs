using System.ComponentModel.DataAnnotations.Schema;

namespace MinistryOfWarerResources.Models
{
    public class EmpModel
    {

        public int Id { get; set; }
        public string EmpFullName { get; set; }
        public string EmpNumber { get; set; }
        public int EmpAge { get; set; }

        [ForeignKey("DeptTable")]
        public int EmpDep { get; set; }


        public decimal EmpSalary { get; set; } 
        public string EmploymentStatus { get; set; }
        public string City { get; set; }
        public DateTime DateOfEmployemnt { get; set; }
        public string EmpImagePath { get; set; }



        public DepModel DeptTable { get; set; }


    }
}
