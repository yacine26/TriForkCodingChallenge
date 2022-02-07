using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YacineCodingChallenge.Models;

namespace CodingChallenge.UnitTests
{
    [TestClass]
    public class GroupsTests
    {
        [TestMethod]
        public void finishTrip_scenario1()
        {
            // arrange
            var group = new Group("Stockholm");

            group.AddMember("John");
            group.AddMember("Peter");
            group.AddMember("Mary");

            group.AddExpense("John", 500, "Hotel");
            group.AddExpense("Mary", 150, "Restaurant");
            group.AddExpense("Peter", 100, "Sightseeing");

            // Act
            group.FinishTrip();

            // Assert
            List<Transaction> result = new List<Transaction>();
            result.Add(new Transaction("Peter", "John", 150));
            result.Add(new Transaction("Mary", "John", 100));

            CollectionAssert.AreEquivalent(group.Transactions, result);

        }

        [TestMethod]
        public void finishTrip_scenario2()
        {
            // arrange
            var group = new Group("Roma");

            group.AddMember("John");
            group.AddMember("Peter");
            group.AddMember("Mary");

            group.AddExpense("John", 200, "Hotel");
            group.AddExpense("Mary", 300, "Restaurant");
            group.AddExpense("Peter", 100, "Sightseeing");

            // Act
            group.FinishTrip();

            // Assert
            List<Transaction> result = new List<Transaction>();
            result.Add(new Transaction("Peter", "Mary", 100));

            CollectionAssert.AreEquivalent(group.Transactions, result);
        }
    }
}
