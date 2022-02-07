using Microsoft.VisualStudio.TestTools.UnitTesting;
using YacineCodingChallenge.Models;

namespace CodingChallenge.UnitTests
{
    [TestClass]
    public class MembersTests
    {
        [TestMethod]
        public void pay_500_and_200_Returns700()
        {
            var member = new Member("Yacine");
            //balance should be initializd 
            Assert.AreEqual(member.Balance, 0);
            
            //after paying 200 and 500 , balance should be 700
            member.Pay(500);
            member.Pay(200);

            Assert.AreEqual(member.Balance, 700);
        }
    }
}
