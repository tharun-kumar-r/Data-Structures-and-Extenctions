using Pattern_Searching_Algorithms;
using System;

class Program
{
    static void Main()
    {
        string text = "aabcabcabdeabc";
        string pattern = "abc";
        Console.WriteLine($"Native Searcgh Algorithem ith input Text: {text} And Pattern: {pattern}");    
        NativeSearch_alogorithem.NativeSearch(text, pattern);



        int prime = 101;
        Console.WriteLine($"\nRabinKarp Searcgh Algorithem ith input Text: {text} And Pattern: {pattern}");
        RabinKarpSearch_Algorithms.RabinKarpSearch(text, pattern, prime);

        Console.WriteLine($"\nKMP Algorithm ith input Text: {text} And Pattern: {pattern}");

        KMPSearch_Algorithem.KMPSearch(pattern, text);
    }





}