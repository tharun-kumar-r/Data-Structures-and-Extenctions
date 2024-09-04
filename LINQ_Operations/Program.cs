using LINQ_Operations;
using System;


class Program
{
    public static void Main()
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
