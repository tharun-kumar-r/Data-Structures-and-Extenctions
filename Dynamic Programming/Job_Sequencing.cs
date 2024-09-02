using System;
using System.Linq;

public class Job
{
    public string Id { get; set; }
    public int Profit { get; set; }
    public int Deadline { get; set; }
}

public class Job_Sequencing
{
    public static int MaxProfit(Job[] jobs)
    {
    
        var sortedJobs = jobs.OrderByDescending(j => j.Profit).ToArray();

        
        int maxDeadline = jobs.Max(j => j.Deadline);

       
        string[] result = new string[maxDeadline];
        bool[] slot = new bool[maxDeadline];

        int totalProfit = 0;

       
        foreach (var job in sortedJobs)
        {
         
            for (int j = Math.Min(maxDeadline, job.Deadline) - 1; j >= 0; j--)
            {
             
                if (!slot[j])
                {
                    slot[j] = true;
                    result[j] = job.Id;
                    totalProfit += job.Profit;
                    break;
                }
            }
        }

       
        Console.WriteLine("Scheduled jobs: " + string.Join(", ", result.Where(r => r != null)));
        return totalProfit;
    }

    public static void Main()
    {
        Job[] jobs = {
            new Job { Id = "J1", Profit = 20, Deadline = 2 },
            new Job { Id = "J2", Profit = 25, Deadline = 2 },
            new Job { Id = "J3", Profit = 15, Deadline = 1 },
            new Job { Id = "J4", Profit = 40, Deadline = 4 },
            new Job { Id = "J5", Profit = 5, Deadline = 3 },
            new Job { Id = "J6", Profit = 10, Deadline = 3 },
            new Job { Id = "J7", Profit = 9, Deadline = 4 }
        };

        
        int maxProfit = MaxProfit(jobs);

    
        Console.WriteLine("Maximum Profit: " + maxProfit);
    }
}
