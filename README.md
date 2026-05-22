# EmployeeManagementSystem
A full-stack employee management web application built on ASP.NET MVC with role-based authentication, complete CRUD functionality, and SQL Server database integration via stored procedures.


Features
- Admin and standard user roles with separate access levels
- Employee record management — create, view, edit, and delete
- User authentication and registration with CSRF protection
- Database operations via ADO.NET and SQL Server stored procedures
- Clean MVC architecture with Razor Views
  

Prerequisites
- Visual Studio 2022 (with ASP.NET and web development workload)
- SQL Server Express
- SQL Server Management Studio (SSMS)
  

Steps to set up and run the project
1. Clone the repository
2. Set up the database
   - Open SQL Server Management Studio
   - Create a new database named Employee
   - Run the SQL scripts to create the required tables and stored procedures (getdetails, create_emp, update_emp, delete_emp)
3. Configure the connection string
   - Open Models/Emp_DAL.cs
   - Update the connection string if your SQL Server instance name differs: Server=localhost\\SQLEXPRESS; Database=Employee; Trusted_Connection=True
4. Run the project
   - Open the solution file (Employee.sln) in Visual Studio
   - Build the solution (Ctrl + Shift + B)
   - Press F5 to run

