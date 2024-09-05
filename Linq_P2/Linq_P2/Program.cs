using Linq_P2;
using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        Linqoperations();
        XMLOpp.XMLopp();
    }

    

public static void Linqoperations()
    {
        var customer = Customers.ShowCustomers().Select(x => x);
        Console.WriteLine("****Table Customers****\n");
        foreach (var c in customer)
        {
            Console.WriteLine($"Cid: {c.Id} | Name: {c.Name} | Age {c.Age} | Pincode: {c.Pincode} | Gender: {c.Gender}");
        }

        var Ordrs = Orders.ShowOrders().Select(x => x);
        Console.WriteLine($"\n****Table Orders****\n");
        foreach (var c in Ordrs)
        {
            Console.WriteLine($"Oid: {c.Oid} | Cid: {c.Cid} |  Address {c.Address} | Datetime: {c.Datetime}");
        }

        querybased();
        Lamdabased();
    }

    public static void querybased()
    {

        var Qorder = from o in Orders.ShowOrders()
                     join c in Customers.ShowCustomers()
                     on o.Cid equals c.Id
                     select new
                     {
                         orderid = o.Oid,
                         name = c.Name,
                         Address = o.Address,
                         Dated = o.Datetime
                     };
        Console.WriteLine($"\n****Orders Details Inner Joins****\n");
        foreach (var c in Qorder)
        {
            Console.WriteLine($"Oid: {c.orderid} | Name: {c.name}  |  Address {c.Address} | Datetime: {c.Dated}");
        }


            Console.WriteLine($"\n****Orders Details Left Joins****\n");

                var QorderL = from c in Customers.ShowCustomers()
                              join o in Orders.ShowOrders()
                              on c.Id equals o.Cid into orderGroup
                              from order in orderGroup.DefaultIfEmpty()
                              select new
                              {
                                  orderid = order?.Oid,
                                  name = c.Name,
                                  Address = order?.Address,
                                  Dated = order?.Datetime
                              };

                foreach (var result in QorderL)
                {
                    Console.WriteLine($"Order ID: {result.orderid ?? 0} | Name: {result.name} | Address: {result.Address ?? "NULL"} | Dated: {result.Dated?.ToString() ?? "NULL"}");
                }


        Console.WriteLine($"\n****Orders Details Right Joins****\n");

        var Qorderr = from o in Orders.ShowOrders()
                      join c in Customers.ShowCustomers()
                      on o.Cid equals c.Id into customerGroup
                      from customer1 in customerGroup.DefaultIfEmpty()
                      select new
                      {
                          orderid = o.Oid,
                          name = customer1?.Name ?? "NULL",
                          Address = o.Address ?? "NULL",
                          Dated = o.Datetime?.ToString() ?? "NULL"
                      };

        foreach (var result in Qorderr)
        {
            Console.WriteLine($"Order ID: {result.orderid} | Name: {result.name} | Address: {result.Address} | Dated: {result.Dated}");
        }

        Console.WriteLine($"\n****Orders and Customers Cross Join****\n");

        var crossJoinResult = from c in Customers.ShowCustomers()
                              from o in Orders.ShowOrders()
                              select new
                              {

                                  Customer = c,
                                  Order = o
                              };

        foreach (var result in crossJoinResult)
        {
            Console.WriteLine($"Customer: {result.Customer.Name}, Pincode: {result.Customer.Pincode} | Order ID: {result.Order.Oid}, Address: {result.Order.Address}");
        }
        

    }


    public static void Lamdabased()
    {

        Console.WriteLine($"\n****Orders Details Inner Joins (Lambda)****\n");

        var innerJoin = Orders.ShowOrders()
            .Join(Customers.ShowCustomers(),
                o => o.Cid,
                c => c.Id,
                (o, c) => new
                {
                    orderid = o.Oid,
                    name = c.Name,
                    Address = o.Address,
                    Dated = o.Datetime
                });

        foreach (var result in innerJoin)
        {
            Console.WriteLine($"Oid: {result.orderid} | Name: {result.name} | Address: {result.Address} | Datetime: {result.Dated}");
        }


        Console.WriteLine($"\n****Orders Details Left Joins (Lambda)****\n");

        var leftJoin = Customers.ShowCustomers()
            .GroupJoin(Orders.ShowOrders(),
                c => c.Id,
                o => o.Cid,
                (c, orderGroup) => new { c, orderGroup = orderGroup.DefaultIfEmpty() })
            .SelectMany(x => x.orderGroup, (x, order) => new
            {
                orderid = order?.Oid,
                name = x.c.Name,
                Address = order?.Address,
                Dated = order?.Datetime
            });

        foreach (var result in leftJoin)
        {
            Console.WriteLine($"Order ID: {result.orderid ?? 0} | Name: {result.name} | Address: {result.Address ?? "NULL"} | Dated: {result.Dated?.ToString() ?? "NULL"}");
        }


        Console.WriteLine($"\n****Orders Details Right Joins (Lambda)****\n");

        var rightJoin = Orders.ShowOrders()
            .GroupJoin(Customers.ShowCustomers(),
                o => o.Cid,
                c => c.Id,
                (o, customerGroup) => new { o, customerGroup = customerGroup.DefaultIfEmpty() })
            .SelectMany(x => x.customerGroup, (x, customer) => new
            {
                orderid = x.o.Oid,
                name = customer?.Name ?? "NULL",
                Address = x.o.Address,
                Dated = x.o.Datetime?.ToString() ?? "NULL"
            });

        foreach (var result in rightJoin)
        {
            Console.WriteLine($"Order ID: {result.orderid} | Name: {result.name} | Address: {result.Address} | Dated: {result.Dated}");
        }

    }
}