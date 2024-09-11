using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entityframework_CURD
{
    internal class Program
    {
        static WiproEntities dt = new WiproEntities();
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Insert");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        display();
                        break;
                    case 2:
                        insert();
                        break;
                    case 3:
                        update();
                        break;
                    case 4:
                        del();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }

            }
        }



        public static void del()
        {
            Console.WriteLine("Enter the Emp Id to Delete");
            int id = Convert.ToInt32(Console.ReadLine());
            var emp = dt.employees.Find(id);

            dt.employees.Remove(emp);
            dt.SaveChanges();
            Console.WriteLine($"\n --------------Employee {emp.name} deleted to Database!------------.");

        }
            public static void update()
        {
            Console.WriteLine("Enter the Emp Id to Update");
            int id = Convert.ToInt32(Console.ReadLine());

            var emp = dt.employees.Find(id);
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Gender");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter the age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the salary");
            int Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Dept Id From: " + string.Join(", ", dt.departments.Select(x => new { ID = x.id + ": " + x.deptname }).ToList()));
            int deptid = Convert.ToInt32(Console.ReadLine());

            emp.name = name;
            emp.age = age;  
            emp.deptid = deptid;
            emp.salary = Salary;
            emp.gender = gender;
            dt.SaveChanges();
            Console.WriteLine($"\n --------------Employee {name} Updated to Database!------------.");

        }

            public static void insert()
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Gender");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter the age");
            int age = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter the salary");
            int Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Dept Id From: " +  string.Join(", " , dt.departments.Select(x=>new { ID = x.id + ": " + x.deptname }).ToList()));
            int deptid = Convert.ToInt32(Console.ReadLine());

            dt.employees.Add(new employee { name = name, age = age, gender = gender, salary = Salary, deptid = deptid });
            dt.SaveChanges();
            Console.WriteLine($"\n --------------Employee {name} Add to Database!------------.");


        }
        public static void display()
        {
            var emp = dt.employees.Select(x => x);

            Console.WriteLine("_____________Display Employees_____________");
            foreach (var e in emp)
            {
                Console.WriteLine($"Employee ID: {e.id} | Name: {e.name} | Gender: {e.gender} | Age: {e.age} | Department: {dt.departments.Where(x => x.id == e.deptid).Select(x => x.deptname).First()}  ");
            }
            Console.WriteLine();

        }
    }
}
