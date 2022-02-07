using System;
namespace YacineCodingChallenge.Models
{
    public class Transaction
    {

        public string From;
        public string To;
        public float Amount;

        public Transaction(string From, string To, float Amount)
        {
            this.From = From;
            this.To = To;
            this.Amount = Amount;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Transaction o = (Transaction)obj;
            return (this.From == o.From &&
                this.To == o.To &&
                this.Amount == o.Amount);
        }

        public override int GetHashCode()
        {
            return this.From.GetHashCode();
        }
    }
}
