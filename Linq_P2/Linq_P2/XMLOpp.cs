using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq_P2
{
    public class XMLOpp
    {

        public static void XMLopp()
        {
            string filePath = @"D:\TempFiles\myboox.xml";

            XDocument xdoc = new XDocument(
                new XElement("bookstore",
                    new XElement("book",
                        new XAttribute("title", "The India"),
                        new XAttribute("author", "Tharun"),
                        new XAttribute("price", "2232")),
                    new XElement("book",
                        new XAttribute("title", "C# Coding for Beginners"),
                        new XAttribute("author", "Microsoft"),
                        new XAttribute("price", "3975")),
                    new XElement("book",
                        new XAttribute("title", "XML Doc"),
                        new XAttribute("author", "XMLI"),
                        new XAttribute("price", "24595"))
                )
            );


            xdoc.Save(filePath);
            Console.WriteLine($"\nCreating a Book with the location {filePath}");

            XDocument loadedXDoc = XDocument.Load(filePath);


            Console.WriteLine("All book details:");
            foreach (var book in loadedXDoc.Descendants("book"))
            {
                string title = (string)book.Attribute("title");
                string author = (string)book.Attribute("author");
                string price = (string)book.Attribute("price");

                Console.WriteLine($"Title: {title} | Author: {author} | Price: {price}");
            }


            var tharunBooks = loadedXDoc.Descendants("book")
                                        .Where(b => (string)b.Attribute("author") == "Tharun")
                                        .Select(b => (string)b.Attribute("title"));

            Console.WriteLine("\nBooks authored by Tharun:");
            foreach (var title in tharunBooks)
            {
                Console.WriteLine(title);
            }


            var averagePrice = loadedXDoc.Descendants("book")
                                         .Average(b => (double)b.Attribute("price"));

            Console.WriteLine($"\nAverage price of all books: {averagePrice}");
        }

    }
}
