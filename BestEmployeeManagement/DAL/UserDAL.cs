using BestEmployeeManagement.Helpers;
using BestEmployeeManagement.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

namespace BestEmployeeManagement.Models
{
    public class UserDAL
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["BestEmployeeManagementConnection"].ConnectionString;

        public List<RoleModel> GetRoles()
        {
            var roles = new List<RoleModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT RoleId, RoleName FROM Role", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new RoleModel
                            {
                                RoleId = reader.GetInt32(0),
                                RoleName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return roles;
        }

        public ResponseModel RegisterUser(RegisterUserModel user)
        {
            var response = new ResponseModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_RegisterUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@UniqueUserId", user.UniqueUserId);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", CryptoHelper.Encrypt(user.Password));

                    try
                    {
                        command.ExecuteNonQuery();
                        response.Status = true;
                        response.Message = "User registered successfully.";
                    }
                    catch (Exception ex)
                    {
                        response.Status = false;
                        response.Message = ex.Message;
                        Logger.WriteLog($"Error in RegisterUser: {ex.Message}");
                    }
                }
            }
            return response;
        }

        public ResponseModel UserLogin(RegisterUserModel user)
        {
            var response = new ResponseModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_UserLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", user.Username);

                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var storedPassword = reader.GetString(3);

                                if (storedPassword == CryptoHelper.Encrypt(user.Password))
                                {
                                  
                                    response.Status = true;
                                    response.Message = "Login successful.";

                                    reader.Close(); 
                                    using (var updateCommand = new SqlCommand("UPDATE UserRegistration SET LastLoginDate = GETDATE() WHERE Username = @Username", connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@Username", user.Username);
                                        updateCommand.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    response.Status = false;
                                    response.Message = "Invalid credentials.";
                                }
                            }
                            else
                            {
                                response.Status = false;
                                response.Message = "User not found.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.Status = false;
                        response.Message = "An error occurred during login.";
                        Logger.WriteLog($"Error in UserLogin: {ex.Message}");
                    }
                }
            }
            return response;
        }


        public ResponseModel ForgotPassword(ForgotPasswordModel model)
        {
            var response = new ResponseModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Username, Email FROM UserRegistration WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", model.Username);

                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var username = reader.GetString(0);
                                var email = reader.GetString(1);

                                // Use the password provided by the user
                                var encryptedPassword = CryptoHelper.Encrypt(model.NewPassword);

                                using (var updateCommand = new SqlCommand("sp_ForgotPassword", connection))
                                {
                                    updateCommand.CommandType = CommandType.StoredProcedure;
                                    updateCommand.Parameters.AddWithValue("@Username", username);
                                    updateCommand.Parameters.AddWithValue("@NewPassword", encryptedPassword);

                                    updateCommand.ExecuteNonQuery();
                                }

                                response.Status = true;
                                response.Message = "Your password has been updated successfully. Please login with your new password.";
                            }
                            else
                            {
                                response.Status = false;
                                response.Message = "User not found.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.Status = false;
                        response.Message = "An error occurred while processing your request.";
                        Logger.WriteLog($"Error in ForgotPassword: {ex.Message}");
                    }
                }
            }
            return response;
        }
    }


}