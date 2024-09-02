using System;
using System.Linq;

public class Item
{
    public char Name { get; set; }
    public double Profit { get; set; }
    public double Weight { get; set; }
    public double Ratio => Profit / Weight;
}

public class FractionalKnapsack
{
    public static void Main()
    {
        Item[] items = {
            new Item { Name = 'A', Profit = 6, Weight = 1 },
            new Item { Name = 'B', Profit = 10, Weight = 2 },
            new Item { Name = 'C', Profit = 8, Weight = 4 },
            new Item { Name = 'D', Profit = 4, Weight = 2 },
            new Item { Name = 'E', Profit = 12, Weight = 6 },
            new Item { Name = 'F', Profit = 14, Weight = 7 }
        };


        Console.Write("Enter the weight limit of the knapsack: ");
        double weightLimit;
        while (!double.TryParse(Console.ReadLine(), out weightLimit) || weightLimit <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number for the weight limit: ");
        }


        var (maxProfit, itemsTaken) = MaxProfit(items, weightLimit);


        Console.WriteLine($"Maximum Profit: {maxProfit}");
        Console.WriteLine("Items taken:");
        foreach (var (itemName, weightTaken, profit) in itemsTaken)
        {
            Console.WriteLine($"Item {itemName}: Weight Taken = {weightTaken}, Profit = {profit}");
        }
    }
    public static (double totalProfit, (char itemName, double weightTaken, double profit)[] itemsTaken) MaxProfit(Item[] items, double weightLimit)
    {

        var sortedItems = items.OrderByDescending(i => i.Ratio).ToArray();

        double totalProfit = 0;
        double remainingWeight = weightLimit;
        var itemsTaken = new (char itemName, double weightTaken, double profit)[items.Length];
        int index = 0;

        foreach (var item in sortedItems)
        {
            if (remainingWeight == 0)
                break;


            double weightToTake = Math.Min(item.Weight, remainingWeight);
            double profitToTake = (weightToTake / item.Weight) * item.Profit;

            totalProfit += profitToTake;
            remainingWeight -= weightToTake;

            if (weightToTake > 0)
            {
                itemsTaken[index++] = (item.Name, weightToTake, profitToTake);
            }
        }


        Array.Resize(ref itemsTaken, index);

        return (totalProfit, itemsTaken);
    }

}

