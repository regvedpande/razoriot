using System.Web.Mvc;
using BestEmployeeManagement.DAL;
using BestEmployeeManagement.Models;

namespace BestEmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeController()
        {
            _employeeDAL = new EmployeeDAL();
        }

        public ActionResult Index()
        {
            var employeeList = _employeeDAL.GetEmployeeList();
            return View(employeeList);
        }

        public ActionResult AddEmployee()
        {
            ViewBag.Positions = _employeeDAL.GetPositions();
            ViewBag.Departments = _employeeDAL.GetDepartments();
            ViewBag.EmployeeTypes = _employeeDAL.GetEmployeeTypes();
            ViewBag.Branches = _employeeDAL.GetBranches();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel employee)
        {
            var response = _employeeDAL.AddEmployee(employee);
            if (response.Status)
            {
                return Json(new { Status = true, Message = "Employee added successfully." });
            }
            else
            {
                return Json(new { Status = false, Message = response.Message });
            }
        }

        public ActionResult EditEmployee(int id)
        {
            var employee = _employeeDAL.GetEmployeeById(id);
            ViewBag.Positions = _employeeDAL.GetPositions();
            ViewBag.Departments = _employeeDAL.GetDepartments();
            ViewBag.EmployeeTypes = _employeeDAL.GetEmployeeTypes();
            ViewBag.Branches = _employeeDAL.GetBranches();
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel employee)
        {
            var response = _employeeDAL.UpdateEmployee(employee);
            if (response.Status)
            {
                return Json(new { Status = true, Message = "Employee updated successfully." });
            }
            else
            {
                return Json(new { Status = false, Message = response.Message });
            }
        }

        public ActionResult DeleteEmployee(int id)
        {
            var response = _employeeDAL.DeleteEmployee(id);
            if (response.Status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = response.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult GetPositions()
        {
            var positions = _employeeDAL.GetPositions();
            return Json(positions, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepartments()
        {
            var departments = _employeeDAL.GetDepartments();
            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeeTypes()
        {
            var employeeTypes = _employeeDAL.GetEmployeeTypes();
            return Json(employeeTypes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBranches()
        {
            var branches = _employeeDAL.GetBranches();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeeListWithPagination(int pageNumber, int pageSize, string searchTerm = "")
        {
            var employeeList = _employeeDAL.GetEmployeeListWithPagination(pageNumber, pageSize, searchTerm);
            return PartialView("_EmployeeListPartial", employeeList);
        }

        public ActionResult SearchEmployees(string searchTerm)
        {
            var employeeList = _employeeDAL.SearchEmployees(searchTerm);
            return PartialView("_EmployeeListPartial", employeeList);
        }
    }

}
