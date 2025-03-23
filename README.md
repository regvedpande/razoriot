# 🚀 Razor IoT : Real-Time Insight Platform  

An avant-garde IoT solution delivering real-time data, unmatched scalability, and a futuristic user experience.  


---

## 🌟 Overview  

**Razor IoT** is a cutting-edge **real-time monitoring** and **control platform** built on **ASP.NET Core** with **Razor Pages/MVC**. It integrates **SignalR** for live updates, **Azure IoT** for cloud connectivity, and **CryptoHelper** for secure data encryption.  

✅ **Live device monitoring** with real-time updates  
✅ **Secure authentication** with role-based access control  
✅ **Advanced cryptography** for data security  
✅ **Scalable cloud-ready architecture**  

---

## 📂 Project Structure  

```
📦 RazorIoT/
 ├── 📁 App_Start/             # Application configurations  
 │    ├── BundleConfig.cs  
 │    ├── FilterConfig.cs  
 │    └── RouteConfig.cs  
 │  
 ├── 📁 Controllers/           # MVC Controllers  
 │    ├── AccountController.cs  
 │    ├── EmployeeController.cs  
 │    ├── HomeController.cs  
 │    ├── LoginController.cs  
 │  
 ├── 📁 DAL/                   # Data Access Layer  
 │    ├── EmployeeDAL.cs  
 │    ├── UserDAL.cs  
 │    ├── ReferenceDataModel.cs  
 │  
 ├── 📁 Helpers/               # Utility Classes  
 │    ├── CryptoHelper.cs  
 │    ├── Logger.cs  
 │  
 ├── 📁 Models/                # Data Models  
 │    ├── BranchModel.cs  
 │    ├── DepartmentModel.cs  
 │    ├── EmployeeModel.cs  
 │    ├── EmployeeTypeModel.cs  
 │    ├── ErrorLogModel.cs  
 │    ├── ForgotPasswordModel.cs  
 │    ├── PositionModel.cs  
 │    ├── RegisterUserModel.cs  
 │    ├── ResponseModel.cs  
 │    ├── RoleModel.cs  
 │    ├── UserRegistrationModel.cs  
 │  
 ├── 📁 Views/                 # Razor Views  
 │    ├── 📁 Account/  
 │    ├── 📁 Employee/  
 │    │    ├── AddEmployee.cshtml  
 │    │    ├── EditEmployee.cshtml  
 │    │    ├── EmployeeList.cshtml  
 │    │    ├── Index.cshtml  
 │    ├── 📁 Home/  
 │    ├── 📁 Login/  
 │    │    ├── ForgotPassword.cshtml  
 │    │    ├── Login.cshtml  
 │    │    ├── Register.cshtml  
 │    ├── 📁 Shared/  
 │    │    ├── _Layout.cshtml  
 │    │    ├── Error.cshtml  
 │    │    ├── _ViewStart.cshtml  
 │  
 ├── 📁 Scripts/               # JavaScript Files  
 │  
 ├── Global.asax               # Global Application Events  
 ├── Web.config                # Application Configuration  
 ├── packages.config           # NuGet Package References  
 ├── favicon.ico               # Website Icon  
 ├── README.md                 # Documentation  
```

---

## 🚀 Getting Started  

### 📌 Prerequisites  
- [.NET 6 or later](https://dotnet.microsoft.com/download)  
- [Visual Studio 2022](https://visualstudio.microsoft.com/)  
- [SQL Server or PostgreSQL](https://www.postgresql.org/)  

### 📥 Clone the Repository  
```sh
git clone https://github.com/regvedpande/razoriot.git
cd razoriot
```

### 🛠 Configure Database  
1. Update `appsettings.json` or `Web.config` with your **database connection string**.  
2. Run **database migrations** if applicable.  

### ▶️ Run the Application  
```sh
dotnet run
```
Or, open the solution in **Visual Studio** and press `F5`.

---

## 🔥 Features  

🚀 **Real-Time Monitoring with SignalR**  
🔐 **Secure Authentication & Authorization**  
🔒 **Advanced Cryptography for Data Security**  
📊 **Live Dashboard with Data Analytics**  
📡 **Cloud-Ready & Scalable Architecture**  

---

## 🔒 Security  

- **CryptoHelper**: Encrypts sensitive data using **secure hashing algorithms**.  
- **Role-Based Access Control (RBAC)**: Restricts access to **authorized users**.  
- **Logging & Error Handling**: Detailed logs stored for debugging and monitoring.  

---

## 🤝 Contributing  

💡 **Want to contribute?** Follow these steps:  
1. **Fork the repository**  
2. **Create a new branch** (`feature-branch`)  
3. **Commit your changes**  
4. **Push to GitHub** and **submit a PR** 🚀  

---

## 📜 License  

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.  

---

## 📞 Contact  

For any inquiries or support, open an **issue** or contact:  
📧 **Email:** [regregd@outlook.com](mailto:regregd@outlook.com)  
🌐 **GitHub:** [@regvedpande](https://github.com/regvedpande)  

---

✨ **Razor IoT** – Powering the future of real-time IoT insights! 🚀  
