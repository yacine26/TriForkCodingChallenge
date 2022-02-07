using System;
using System.Collections.Generic;
using System.Text;

namespace YacineCodingChallenge.Interfaces
{
    interface IGroup
    {
        void AddMember(string MemberName);
        void AddExpense(string MemberName, float Amount, string ExpenseName);
        void ShowBalance(string MemberName);
        void FinishTrip();
    }
}
