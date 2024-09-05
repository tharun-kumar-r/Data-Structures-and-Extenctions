using LINQ_Operations;
using System;


class Program
{    public class students
    {
        public int regno { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public String brachid { get; set; }
        public string sem { get; set; }
    }

    public class branch
    {
        public int b_id { get; set; }
        public string b_name { get; set; }
    }

    public static void Main(string[] args)
    {
        List<students> std = new List<students>{
                new students{ regno =  1, name = "Tharun", email = "rajtharunir@gmail.com", sem="3", brachid="1"},
                new students{ regno =  2, name = "kumar", email = "kumar@gmail.com",sem="3", brachid="2"},
                new students{ regno =  3, name = "Mahesh", email = "mahesh@gmail.com", sem="1", brachid="1"},
                new students{ regno =  4, name = "Madhan", email = "madhan@gmail.com", sem="1", brachid="1"}


            };

        List<branch> brnch = new List<branch> {
                new branch { b_id = 1, b_name = "CSE" }, new branch { b_id = 2, b_name = "EC"} };


        std.Select(x=> x).OrderBy(x => x.sem).ToList().ForEach(z => Console.WriteLine($"Regno: {z.regno} | Name: {z.name} | Email: {z.email} | Sem: {z.sem} | Branch: { brnch.Where(x => x.b_id == Convert.ToInt32(z.brachid)).Select(s => s.b_name).FirstOrDefault() }"));
        


        

    }


    public static void test()
    {
        List<Person> prson = new List<Person>
        {
            new Person{p_id = 1, p_fname = "Tharun", p_lname = "R", p_age = 20, p_Sal = 245.5f },
            new Person{p_id = 1, p_fname = "Arun", p_lname = "A", p_age = 60, p_Sal = 3324.7f },
            new Person{p_id = 1, p_fname = "Manoj", p_lname = "P", p_age = 80, p_Sal = 32455.45f },
            new Person{p_id = 1, p_fname = "Yuva", p_lname = "K", p_age = 25, p_Sal = 753545.34f },
            new Person{p_id = 1, p_fname = "Krish", p_lname = "J", p_age = 43, p_Sal = 42134.43f }


        };

        var ageover30 = prson.Where(x => x.p_age > 30).Select(x => new { fname = x.p_fname, lname = x.p_lname , age = x.p_age});
        Console.WriteLine("Person Whos Age > 30 is \n" + String.Join("\n", ageover30.ToList()));

        var sortname = prson.Select(x => new { x.p_fname, x.p_lname }).OrderBy(a => ( a.p_fname, a.p_lname));
        Console.WriteLine("\nSorted Person Names \n" + String.Join("\n", sortname.ToList()));

        Console.WriteLine("\nAverage Person Age \n" + prson.Select(x => x.p_age).Average());

        Console.WriteLine("\nYoungest Person " + prson.Where(x => x.p_age <= prson.Min(xy => xy.p_age)).Select(x => x.p_fname + " "+ x.p_lname).FirstOrDefault());

        Console.WriteLine("\nOldest Person " + prson.Where(x => x.p_age >= prson.Max(xy => xy.p_age)).Select(x => x.p_fname + " " + x.p_lname).FirstOrDefault());

        Console.WriteLine("\nOldest Person " + prson.Where(x => x.p_Sal >= prson.Average(xy => xy.p_Sal)).Select(x => x.p_fname + " " + x.p_lname).FirstOrDefault());

    }
}
