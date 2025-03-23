using System;

namespace BestEmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public int EmployeeTypeId { get; set; }
        public int BranchId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public string TypeName { get; set; }
        public string BranchName { get; set; }
    }
}