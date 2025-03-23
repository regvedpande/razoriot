using BestEmployeeManagement.Models;
using System.Collections.Generic;

namespace BestEmployeeManagement.DAL
{
    public class ReferenceDataModel
    {
        public List<PositionModel> Positions { get; set; }
        public List<DepartmentModel> Departments { get; set; }
        public List<EmployeeTypeModel> EmployeeTypes { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<BranchModel> Branches { get; set; }
    }

}