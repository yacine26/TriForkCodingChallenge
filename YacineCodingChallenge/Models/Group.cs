using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YacineCodingChallenge.Models
{
    public class Group
    {
        public string Name;
        public List<Member> Members = new List<Member>();
        public List<Expense> Expenses = new List<Expense>();
        public List<Transaction> Transactions = new List<Transaction>();

        public Group(string Name)
        {
            this.Name = Name;
            Console.WriteLine($"{Name} : Group Created ");
        }

        public void AddMember(string MemberName)
        {
            this.Members.Add(new Member(MemberName));
            Console.WriteLine($"Member {MemberName} added to group {Name}");
        }


        public void AddExpense(string MemberName, float Amount, string ExpenseName)
        {
        
            {
                this.Expenses.Add(new Expense(ExpenseName, MemberName, Amount));
                // Finds the Member who paied for the expense
                Member payer = FindMember(MemberName);
                payer.Pay(Amount);
                Console.WriteLine($"Member {MemberName} paied {Amount} Because {ExpenseName}");
            }
          
        }

        //showing each member payment
        public void ShowBalance(string MemberName)
        {
            Member member = FindMember(MemberName);
            Console.WriteLine($"Member {MemberName} has balance : {member.Balance}");
        }

        public void FinishTrip()
        {
            float TripCost = GetTripCostPerMember();

            // continue while someone needs to send or receive money
            while ( Members.FindAll( m => m.Balance.Equals(TripCost)).Count != Members.Count )
            {
                Member paiedLess = PaiedLess();
                Member paiedMore = PaiedMore();
                float AmountToBeSent = TripCost - paiedLess.Balance; // amount that less payer have to pay
                if(AmountToBeSent > (paiedMore.Balance - TripCost)) // if highest payer needs less then AmountToBeSent
                {
                    AmountToBeSent = paiedMore.Balance - TripCost; // send only the amount he should receive
                }
                paiedLess.Balance += AmountToBeSent;
                paiedMore.Balance -= AmountToBeSent;
                Transactions.Add(new Transaction(paiedLess.Name, paiedMore.Name, AmountToBeSent));
                Console.WriteLine($"{paiedLess.Name} sent {AmountToBeSent} to {paiedMore.Name}");
            };
        }

        //finding the member who paid more
        private Member PaiedMore()
        {
            return Members.Aggregate((m1, m2) => {
                if (m1.Balance > m2.Balance)
                {
                    return m1;
                }
                return m2;
            });
        }

        //finding the member who paid less
        private Member PaiedLess()
        {
            return Members.Aggregate((m1, m2) => {
                if (m1.Balance < m2.Balance)
                {
                    return m1;
                }
                return m2;
            });
        }

        // calculate cost to be paied per each member
        private float GetTripCostPerMember()
        {
            return Members.Sum(member => member.Balance) / Members.Count;
        }

        private Member FindMember(string MemberName)
        {
            return Members.Find(member => member.Name.Equals(MemberName));
        }
    }
}
