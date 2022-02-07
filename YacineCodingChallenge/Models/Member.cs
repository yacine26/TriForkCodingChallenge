using System;
namespace YacineCodingChallenge.Models
{
    public class Member
    {
        public string Name;
        public float Balance;

        public Member(string Name)
        {
            this.Name = Name;
            this.Balance = 0f;
        }

        //balance should increment 
        public void Pay(float Balance)
        {
            this.Balance += Balance;
        }
    }
}
