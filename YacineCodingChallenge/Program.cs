using System;
using YacineCodingChallenge.Models;

namespace YacineCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = new Group("Stockholm");

            group.AddMember("John");
            group.AddMember("Peter");
            group.AddMember("Mary");

            group.AddExpense("John", 200, "Hotel");
            group.AddExpense("Mary", 300, "Restaurant");
            group.AddExpense("Peter", 100, "Sightseeing");


            group.ShowBalance("John");
            group.ShowBalance("Peter");
            group.ShowBalance("Mary");

            group.FinishTrip();
            Console.WriteLine("Hello World!");
        }
    }
}
