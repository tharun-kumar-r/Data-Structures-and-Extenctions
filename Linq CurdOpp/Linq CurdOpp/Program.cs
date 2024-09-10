using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Linq_CurdOpp
{
    internal class Program
    {
        public static AppDbContextDataContext context = new AppDbContextDataContext();


      
            static void Main(string[] args)
            {
                AppDbContextDataContext context = new AppDbContextDataContext();

                while (true)
                {
                    Console.WriteLine("\n0. Display Tables");
                    Console.WriteLine("1. Create new employee");
                    Console.WriteLine("2. Delete employee");
                    Console.WriteLine("3. Update employee");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                    case 0:
                        var x = context.Employees.Select(y => y);

                        Console.WriteLine("\nEmployee Table");
                        foreach (var g in x)
                        {
                            Console.WriteLine($"Name: {g.EmployeeName} | Gender: {g.Gender} | Salary: {g.Salary} | Age: {g.Age} | Department: {g.DeptId} ");
                        }

                        var xy = context.Departments.Select(y => y);

                        Console.WriteLine("\nDept Table");
                        foreach (var g in xy)
                        {
                            Console.WriteLine($"Dept Id: {g.DepartmentId} | Department Name: {g.DepartmentName} ");
                        }
                        break;
                    case 1:
                            
                            Console.WriteLine("\nEnter new employee details:");
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Gender: ");
                            string gender = Console.ReadLine();
                            Console.Write("Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Salary: ");
                            decimal salary = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Department ID: ");
                            int deptId = Convert.ToInt32(Console.ReadLine());

                            Employee newEmployee = new Employee
                            {
                                EmployeeName = name,
                                Gender = gender,
                                Age = age,
                                Salary = salary,
                                DeptId = deptId
                            };

                            context.Employees.InsertOnSubmit(newEmployee);
                            context.SubmitChanges();

                            Console.WriteLine("\nNew employee added successfully!");
                            break;
                        case 2:
                            
                            Console.Write("Enter employee name to delete: ");
                            string deleteName = Console.ReadLine();

                            var deleteEmployee = context.Employees.SingleOrDefault(e => e.EmployeeName == deleteName);
                            if (deleteEmployee != null)
                            {
                                context.Employees.DeleteOnSubmit(deleteEmployee);
                                context.SubmitChanges();
                                Console.WriteLine("\nEmployee deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("\nEmployee not found!");
                            }
                            break;
                        case 3:
                       
                            Console.Write("Enter employee name to update: ");
                            string updateName = Console.ReadLine();

                            var updateEmployee = context.Employees.SingleOrDefault(e => e.EmployeeName == updateName);
                            if (updateEmployee != null)
                            {
                                Console.Write("Enter new name: ");
                                updateEmployee.EmployeeName = Console.ReadLine();
                                Console.Write("Enter new gender: ");
                                updateEmployee.Gender = Console.ReadLine();
                                Console.Write("Enter new age: ");
                                updateEmployee.Age = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter new salary: ");
                                updateEmployee.Salary = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter new department ID: ");
                                updateEmployee.DeptId = Convert.ToInt32(Console.ReadLine());

                                context.SubmitChanges();
                                Console.WriteLine("\nEmployee updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("\nEmployee not found!");
                            }
                            break;
                        case 4:
                            
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose again.");
                            break;
                    }
                }
            }
        }
    
}
