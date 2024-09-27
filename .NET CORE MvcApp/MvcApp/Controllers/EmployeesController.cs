using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcApp.Models;
using System.Data.SqlClient;

namespace MvcApp.Controllers
{
 
    public class EmployeesController : Controller
    {
        public string connectionString = "Data Source=DESKTOP-OCT5E0G\\SQLEXPRESS;Initial Catalog=employees;Integrated Security=SSPI";


        public IActionResult All()
        {
            List<Employee> emp = new List<Employee>();
        
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open(); // Make sure to open the connection before executing commands
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    Employee employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Country = reader["Country"].ToString(),
                        Address = reader["Address"].ToString(),
                        DateOfBirth = reader["DateOfBirth"].ToString(), 
                        PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]),
                        Salary = Convert.ToSingle(reader["Salary"])
                    };

                  
                    emp.Add(employee);
                }

                reader.Close();
            }



            ViewBag.data = emp;


            return View();
           
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.CountryList = new SelectList(new[]
 {
        new { Value = "", Text = "Select Country" },
        new { Value = "India", Text = "India" },
        new { Value = "USA", Text = "USA" },
        new { Value = "UK", Text = "UK" },
        new { Value = "Canada", Text = "Canada" },
        new { Value = "Australia", Text = "Australia" }
    }, "Value", "Text");


            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
        
            ViewBag.CountryList = new SelectList(new[]
            {
        new { Value = "", Text = "Select Country" },
        new { Value = "India", Text = "India" },
        new { Value = "USA", Text = "USA" },
        new { Value = "UK", Text = "UK" },
        new { Value = "Canada", Text = "Canada" },
        new { Value = "Australia", Text = "Australia" }
    }, "Value", "Text");

            
            if (ModelState.IsValid)
            {
              
           

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                  
                    con.Open();

                 
                    string query = "INSERT INTO Employee (FirstName, MiddleName, LastName, Email, Age, Country, Address, DateOfBirth, PhoneNumber, Salary) " +
                                   "VALUES (@FirstName, @MiddleName, @LastName, @Email, @Age, @Country, @Address, @DateOfBirth, @PhoneNumber, @Salary)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                      
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@Age", employee.Age);
                        cmd.Parameters.AddWithValue("@Country", employee.Country);
                        cmd.Parameters.AddWithValue("@Address", employee.Address);
                        cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                       
                        cmd.ExecuteNonQuery();
                    }

                  
                    con.Close();
                }

               
                return RedirectToAction("All"); 
            }

           
            return View(employee);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            ViewBag.id = id;

            Employee employee = null;

            ViewBag.CountryList = new SelectList(new[]
            {
        new { Value = "India", Text = "India" },
        new { Value = "USA", Text = "USA" },
        new { Value = "UK", Text = "UK" },
        new { Value = "Canada", Text = "Canada" },
        new { Value = "Australia", Text = "Australia" }
    }, "Value", "Text");

          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

               
                string query = "SELECT * FROM Employee WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Country = reader["Country"].ToString(),
                            Address = reader["Address"].ToString(),
                            DateOfBirth = reader["DateOfBirth"].ToString(),
                            PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]),
                            Salary = Convert.ToSingle(reader["Salary"])
                        };
                    }

                    reader.Close();
                }
            }

         
            if (employee == null)
            {
                return RedirectToAction("All");
            }

            return View(employee); 
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
           
            ViewBag.CountryList = new SelectList(new[]
            {
        new { Value = "India", Text = "India" },
        new { Value = "USA", Text = "USA" },
        new { Value = "UK", Text = "UK" },
        new { Value = "Canada", Text = "Canada" },
        new { Value = "Australia", Text = "Australia" }
    }, "Value", "Text");

            if (ModelState.IsValid)
            {
                
             

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                   
                    string query = "UPDATE Employee SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                                   "Email = @Email, Age = @Age, Country = @Country, Address = @Address, DateOfBirth = @DateOfBirth, " +
                                   "PhoneNumber = @PhoneNumber, Salary = @Salary WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@Id", employee.Id);
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@Age", employee.Age);
                        cmd.Parameters.AddWithValue("@Country", employee.Country);
                        cmd.Parameters.AddWithValue("@Address", employee.Address);
                        cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                       
                        cmd.ExecuteNonQuery();
                    }

                 
                    con.Close();
                }

            
                return RedirectToAction("All");   }

           
            return View(employee);
        }

        [HttpGet]
        public ActionResult Del(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Employee WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                       
                        int rowsAffected = cmd.ExecuteNonQuery();

                        
                        if (rowsAffected == 0)
                        {
                            
                        }
                    }
                }

              
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
               
            }

           
            return RedirectToAction("All"); 
        }



        [HttpGet]
        public ActionResult View(int id)
        {

            ViewBag.id = id;

            Employee employee = null;

            ViewBag.CountryList = new SelectList(new[]
            {
        new { Value = "India", Text = "India" },
        new { Value = "USA", Text = "USA" },
        new { Value = "UK", Text = "UK" },
        new { Value = "Canada", Text = "Canada" },
        new { Value = "Australia", Text = "Australia" }
    }, "Value", "Text");


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();


                string query = "SELECT * FROM Employee WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Country = reader["Country"].ToString(),
                            Address = reader["Address"].ToString(),
                            DateOfBirth = reader["DateOfBirth"].ToString(),
                            PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]),
                            Salary = Convert.ToSingle(reader["Salary"])

                           
                        };

                        ViewBag.id = reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString() + " " + reader["LastName"].ToString();
                    }

                    reader.Close();
                }
            }


            if (employee == null)
            {
                return RedirectToAction("All");
            }

            return View(employee);
        }


    }
}
