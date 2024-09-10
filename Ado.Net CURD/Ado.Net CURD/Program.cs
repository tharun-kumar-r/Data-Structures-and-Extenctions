using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

class Program
{
   public static string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

    public static void Main()
    {
        Random  random = new Random();

        DisplayAllEmployees();
        Console.WriteLine("\n___________________________After EXEC stored Proc ___________________________________________\n");
        storedproc("E-"+ random.Next());


        // ADO .NET Curd perations

        ADO_CURDOPP();



    }


    public static void storedproc(string name)
    {
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            string query = @"GetDeptSalDeptId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empname", name);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["edi"]} | Name: {reader["name"]} | Gender: {reader["gender"]} | Age: {reader["age"]} | Salary: {reader["salary"]} | Department Name: {reader["dname"]}");
            }
            reader.Close();
        }
    }
        public static void ADO_CURDOPP()
    {

        while (true)
        {
            Console.WriteLine("0. Create Tables");
            Console.WriteLine("1. Insert Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Display All Employees");
            Console.WriteLine("5. Display Employee by ID");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 0:
                    Console.WriteLine();
                    createtable();
                 
                    break;
                case 1:
                    Console.WriteLine();
                    InsertEmployee();
                  
                    break;
                case 2:
                    Console.WriteLine();
                    UpdateEmployee();
                    
                    break;
                case 3:
                    Console.WriteLine();
                    DeleteEmployee();
                   
                    break;
                case 4:
                    Console.WriteLine();
                    DisplayAllEmployees();
                    break;
                case 5:
                    Console.WriteLine();
                    DisplayEmployee();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }

       
         
       
       
    }


    public static void DisplayAllEmployees()
    {
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            string query = @"SELECT * FROM emp";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["edi"]} | Name: {reader["name"]} | Gender: {reader["gender"]} | Age: {reader["age"]} | Salary: {reader["salary"]} | Department ID: {reader["did"]}");
            }
            reader.Close();
        }
    }

    public static void createtable()
    {
    try
    {
        using (SqlConnection conn =  new SqlConnection(constr))
        {
            conn.Open();

            string query = @"create table dept(id int, dname varchar(30)); create table emp(edi int identity(1,1) primary key, name varchar(100), gender varchar(20), age int, salary decimal(12, 2), did int )";
            SqlCommand cmd = new SqlCommand(query, conn);
            int sts = cmd.ExecuteNonQuery();
            Console.WriteLine("Table Created!.");
            
          
           
        }
        }
        catch (Exception e)
        {
            Console.WriteLine("Table Already Exist!.");
        }
    }

    public static void InsertEmployee()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter gender: ");
        string gender = Console.ReadLine();
        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter salary: ");
        decimal salary = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter department ID: ");
        int did = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            string query = @"INSERT INTO emp (name, gender, age, salary, did) VALUES (@name, @gender, @age, @salary, @did)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@did", did);
            int sts = cmd.ExecuteNonQuery();
            Console.WriteLine(sts == 1 ? "Employee inserted successfully!" : "Failed to insert employee.");
        }
    }

    public static void UpdateEmployee()
    {

        Console.Write("Enter ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter gender: ");
        string gender = Console.ReadLine();
        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter salary: ");
        decimal salary = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter department ID: ");
        int did = Convert.ToInt32(Console.ReadLine());
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            string query = @"UPDATE emp SET name = @name, gender = @gender, age = @age, salary = @salary, did = @did WHERE edi = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@did", did);
            int sts = cmd.ExecuteNonQuery();
            Console.WriteLine(sts == 1 ? "Employee updated successfully!" : "Failed to update employee.");
        }
    }

    public static void DeleteEmployee()
    {
        Console.Write("Enter ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            string query = @"DELETE FROM emp WHERE edi = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            int sts = cmd.ExecuteNonQuery();
            Console.WriteLine(sts == 1 ? "Employee deleted successfully!" : "Failed to delete employee.");
        }
    }


    public static void DisplayEmployee()
    {
        Console.Write("Enter ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            string query = @"SELECT * FROM emp WHERE edi = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["edi"]} | Name: {reader["name"]} | Gender: {reader["gender"]} | Age: {reader["age"]} | Salary: {reader["salary"]} | Department ID: {reader["did"]}");
            }
            reader.Close();
        }
    }


}