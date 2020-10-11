using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Kassza.Tests
{
    [TestClass]
    public class RsultActivityTest
    {
        [TestMethod]
        public void TestDoCount()
        {
            var cashDesk = new CashDesk();
            GetValuesForCashDesk(cashDesk);
            var activity = new ResultActivity();
            var exceptedResult = new int[] { 1,1,2,10,17,1,1,1,0,1,0,1};
            var bankNotes = new int[] { 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5 };
            var  bankNotesInCashDesk = new int[] { cashDesk.AmountOf20000Ft, cashDesk.AmountOf10000Ft, cashDesk.AmountOf5000Ft, cashDesk.AmountOf2000Ft, cashDesk.AmountOf1000Ft, cashDesk.AmountOf500Ft, cashDesk.AmountOf200Ft, cashDesk.AmountOf100Ft, cashDesk.AmountOf50Ft, cashDesk.AmountOf20Ft, cashDesk.AmountOf10Ft, cashDesk.AmountOf5Ft };

            var ActualResult = activity.IShouldRemoveXCashFromDesk(cashDesk.ClosingBalance, bankNotes, bankNotesInCashDesk);
            Assert.AreEqual(exceptedResult, ActualResult);
        }

        private void GetValuesForCashDesk(CashDesk cashDesk)
        {
            cashDesk.OpeningBalance = 20000;
            cashDesk.ClosingBalance = 97825;
            cashDesk.AmountOf5Ft = 25;
            cashDesk.AmountOf10Ft = 30;
            cashDesk.AmountOf20Ft = 20; //+3
            cashDesk.AmountOf50Ft = 60;
            cashDesk.AmountOf100Ft = 25; //+2
            cashDesk.AmountOf200Ft = 30;
            cashDesk.AmountOf500Ft = 11;
            cashDesk.AmountOf1000Ft = 20; //+1
            cashDesk.AmountOf2000Ft = 10; //+1
            cashDesk.AmountOf5000Ft = 2;
            cashDesk.AmountOf10000Ft = 1;
            cashDesk.AmountOf20000Ft = 1;
        }
        //blokkon lévő összeg: 97825
        //kassza tényleges tartalma: 97825 + 3260
        //kivehető jövedelem: 77825
        //borravalo: 0 + 3260
        //kasszaban maradt váltó: 20000
        //elszámolós papírra : bevételamit kivesz + a váltó (a borravalo nincs benne)
    }
}