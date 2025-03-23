using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using BestEmployeeManagement.Models;

namespace BestEmployeeManagement.DAL
{
    public class EmployeeDAL
    {
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["BestEmployeeManagementConnection"].ConnectionString;

        public List<EmployeeModel> GetEmployeeList()
        {
            var employeeList = new List<EmployeeModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_GetEmployeeList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        employeeList = ReadData<EmployeeModel>(reader);
                    }
                }
            }
            return employeeList;
        }



        public EmployeeModel GetEmployeeById(int id)
        {
            EmployeeModel employee = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_GetEmployeeById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeModel
                            {
                                EmployeeId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Email = reader.GetString(3),
                                DateOfBirth = reader.GetDateTime(4),
                                Gender = reader.GetString(5),
                                PhoneNumber = reader.GetString(6),
                                Address = reader.GetString(7),
                                PositionId = reader.GetInt32(8),
                                DepartmentId = reader.GetInt32(9),
                                JoiningDate = reader.GetDateTime(10),
                                Salary = reader.GetDecimal(11),
                                EmployeeTypeId = reader.GetInt32(12),
                                BranchId = reader.GetInt32(13),
                                CreatedBy = reader.GetString(14),
                                CreatedDate = reader.GetDateTime(15),
                                IsActive = reader.GetBoolean(16),
                                PositionName = reader.GetString(17),
                                DepartmentName = reader.GetString(18),
                                TypeName = reader.GetString(19),
                                BranchName = reader.GetString(20)
                            };
                        }
                    }
                }
            }
            return employee;
        }

        public ResponseModel AddEmployee(EmployeeModel employee)
        {
            var response = new ResponseModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_InsertEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@PositionId", employee.PositionId);
                    command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@EmployeeTypeId", employee.EmployeeTypeId);
                    command.Parameters.AddWithValue("@BranchId", employee.BranchId);
                    command.Parameters.AddWithValue("@CreatedBy", employee.CreatedBy);

                    try
                    {
                        command.ExecuteNonQuery();
                        response.Status = true;
                        response.Message = "Employee added successfully.";
                    }
                    catch (Exception ex)
                    {
                        response.Status = false;
                        response.Message = ex.Message;
                    }
                }
            }
            return response;
        }

        public ResponseModel UpdateEmployee(EmployeeModel employee)
        {
            var response = new ResponseModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_UpdateEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@PositionId", employee.PositionId);
                    command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@EmployeeTypeId", employee.EmployeeTypeId);
                    command.Parameters.AddWithValue("@BranchId", employee.BranchId);

                    try
                    {
                        command.ExecuteNonQuery();
                        response.Status = true;
                        response.Message = "Employee updated successfully.";
                    }
                    catch (Exception ex)
                    {
                        response.Status = false;
                        response.Message = ex.Message;
                    }
                }
            }
            return response;
        }

        public ResponseModel DeleteEmployee(int id)
        {
            var response = new ResponseModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_DeleteEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", id);

                    try
                    {
                        command.ExecuteNonQuery();
                        response.Status = true;
                        response.Message = "Employee deleted successfully.";
                    }
                    catch (Exception ex)
                    {
                        response.Status = false;
                        response.Message = ex.Message;
                    }
                }
            }
            return response;
        }

        public List<PositionModel> GetPositions()
        {
            var positions = new List<PositionModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT PositionId, PositionName FROM Position", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positions.Add(new PositionModel
                            {
                                PositionId = reader.GetInt32(0),
                                PositionName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return positions;
        }

        public List<DepartmentModel> GetDepartments()
        {
            var departments = new List<DepartmentModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT DepartmentId, DepartmentName FROM Department", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new DepartmentModel
                            {
                                DepartmentId = reader.GetInt32(0),
                                DepartmentName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return departments;
        }

        public List<EmployeeTypeModel> GetEmployeeTypes()
        {
            var employeeTypes = new List<EmployeeTypeModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT EmployeeTypeId, TypeName FROM EmployeeType", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeTypes.Add(new EmployeeTypeModel
                            {
                                EmployeeTypeId = reader.GetInt32(0),
                                TypeName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return employeeTypes;
        }

        public List<BranchModel> GetBranches()
        {
            var branches = new List<BranchModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT BranchId, BranchName FROM Branch", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            branches.Add(new BranchModel
                            {
                                BranchId = reader.GetInt32(0),
                                BranchName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return branches;
        }

        public List<EmployeeModel> GetEmployeeListWithPagination(int pageNumber, int pageSize, string searchTerm)
        {
            var employeeList = new List<EmployeeModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_GetEmployeeListWithPagination", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);
                    using (var reader = command.ExecuteReader())
                    {
                        employeeList = ReadData<EmployeeModel>(reader);
                    }
                }
            }
            return employeeList;
        }

        public List<EmployeeModel> SearchEmployees(string searchTerm)
        {
            var employeeList = new List<EmployeeModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_SearchEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);
                    using (var reader = command.ExecuteReader())
                    {
                        employeeList = ReadData<EmployeeModel>(reader);
                    }
                }
            }
            return employeeList;
        }

        private List<T> ReadData<T>(SqlDataReader reader) where T : new()
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties();
            while (reader.Read())
            {
                var item = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var property = properties.FirstOrDefault(p => p.Name.Equals(reader.GetName(i), StringComparison.OrdinalIgnoreCase));
                    if (property != null && reader[i] != DBNull.Value)
                    {
                        property.SetValue(item, reader[i]);
                    }
                }
                list.Add(item);
            }
            return list;
        }
    }
}
