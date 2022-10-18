using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;

namespace Part_7_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menu;
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Lists of Integers");
                Console.WriteLine("2) Lists of Strings");
                Console.WriteLine("X) Exit");
                Console.Write("Enter a selection number to run it: ");
                menu = Console.ReadLine()!.ToLower();

                switch (menu)
                {
                    case "1":
                        IntList();
                        break;
                    case "2":
                        StringList();
                        break;
                    case "x":
                        done = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static void IntList()
        {
            var rand = new Random();
            List<int> nums = new List<int>();
            bool done = false;
            string menu;
            int num;
            for (int ctr = 0; ctr <= 24; ctr++)
                nums.Add(rand.Next(10, 21));
            Console.WriteLine("Here is the list of numbers:");
            foreach (int i in nums)
                Console.Write($"{i}, ");
            Console.WriteLine("");
            

            while (!done)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Sort");
                Console.WriteLine("2) New list");
                Console.WriteLine("3) Remove by value");
                Console.WriteLine("4) Add value");
                Console.WriteLine("5) Number of occurrences of 15");
                Console.WriteLine("6) Largest value");
                Console.WriteLine("7) Smallest value");
                Console.WriteLine("8) Sum and average");
                Console.WriteLine("9) Most frequently occurring");
                Console.WriteLine("10) Number of occurrences by value");
                Console.WriteLine("X) Exit");
                Console.Write("Enter a selection number to run it: ");
                menu = Console.ReadLine()!.ToLower();

                switch (menu)
                {
                    case "1":// Sort
                        nums.Sort();
                        foreach (int i in nums)
                            Console.Write($"{i}, ");
                        Console.WriteLine("");
                        break;
                    case "2":// New list
                        nums.Clear();
                        for (int ctr = 0; ctr <= 24; ctr++)
                            nums.Add(rand.Next(10, 21));
                        Console.WriteLine("Here is the new list of numbers:");
                        foreach (int i in nums)
                            Console.Write($"{i}, ");
                        Console.WriteLine("");
                        break;
                    case "3":// Remove by value
                        Console.Write("Input value to remove");
                        int.TryParse(Console.ReadLine(), out num);
                        while (nums.Contains(num))
                        {
                            nums.Remove(num);
                        }
                        Console.WriteLine($"Removed all occurrences of {num}");
                        foreach (int i in nums)
                            Console.Write($"{i}, ");
                        Console.WriteLine("");
                        break;
                    case "4":// Add value
                        Console.Write("Input value to add");
                        int.TryParse(Console.ReadLine(), out num);
                        nums.Add(num);
                        break;
                    case "5":// Number of occurrences
                        Console.WriteLine($"15 occurres {(from temp in nums where temp.Equals(15) select temp).Count()} times");
                        break;
                    case "6":// Largest value
                        Console.WriteLine($"Largest value: {nums.Max()}");
                        break;
                    case "7":// Smallest value
                        Console.WriteLine($"Smallest value: {nums.Min()}");
                        break;
                    case "8":// Sum and Average
                        var sum = nums.Aggregate((acc, cur) => acc + cur);
                        var average = nums.Aggregate((acc, cur) => acc + cur) / nums.Count;
                        Console.WriteLine($"Sum: {sum}, Average: {average}");
                        break;
                    case "9":// Most frequently occurring
                        var most = nums.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                        Console.WriteLine($"The most frequently occurring number is {most}");
                        break;
                    case "10":// Number of occurrences by value
                        Console.Write("Input value to check for: ");
                        int.TryParse(Console.ReadLine(), out num);
                        Console.WriteLine((from temp in nums where temp.Equals(num) select temp).Count());
                        break;
                    case "x":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static void StringList()
        {
            string menu;
            bool done = false;
            int index;
            string input;
            List<string> words = new List<string>();
            words.Add("CARROT");
            words.Add("BEET");
            words.Add("CELERY");
            words.Add("RADISH");
            words.Add("CABBAGE");

            while (!done)
            {
                Console.WriteLine("Here is the list of vegetables:");
                foreach (string word in words)
                    Console.WriteLine($"{words.IndexOf(word)} - {word}");

                Console.WriteLine("Menu Options:");
                Console.WriteLine("1) Remove by index");
                Console.WriteLine("2) Remove by value");
                Console.WriteLine("3) Search for vegetable");
                Console.WriteLine("4) Add to list");
                Console.WriteLine("5) Sort");
                Console.WriteLine("6) Clear");
                Console.WriteLine("X) Exit");
                Console.Write("Enter a selection number to run it: ");
                menu = Console.ReadLine()!.ToLower();

                switch (menu)
                {
                    case "1":// Remove index
                        Console.Write("Input index: ");
                        int.TryParse(Console.ReadLine(), out index);
                        words.RemoveAt(index);
                        break;
                    case "2":// Remove value
                        Console.Write("Input value: ");
                        input = Console.ReadLine()!.ToUpper();
                        words.Remove(input);
                        break;
                    case "3":// Search
                        Console.Write("Input value: ");
                        input = Console.ReadLine()!.ToUpper();
                        Console.WriteLine($"Found: {words.Exists(x => x.Contains(input))}, Index: {words.IndexOf(input)}");
                        break;
                    case "4":// Add
                        Console.Write("Input value: ");
                        input = Console.ReadLine()!.ToUpper();
                        if (words.Contains(input)){
                            Console.WriteLine("Item already in list");
                        }
                        else
                        {
                            words.Add(input);
                        }
                        break;
                    case "5":// Sort
                        words.Sort();
                        Console.WriteLine("Here is the list of vegetables sorted:");
                        foreach (string word in words)
                            Console.WriteLine($"{words.IndexOf(word)} - {word}");
                        break;
                    case "6":// Clear
                        words.Clear();
                        break;
                    case "x":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}