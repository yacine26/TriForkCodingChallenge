using System;
namespace YacineCodingChallenge.Models
{
    public class Expense
    {
        public string Name;
        public string MemberName;
        public float Amount;

        public Expense(string Name, string MemberName, float Amount)
        {
            this.Name = Name;
            this.MemberName = MemberName;
            this.Amount = Amount;
        }
    }
}
