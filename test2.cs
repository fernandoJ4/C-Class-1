using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeFactorLib; // Assuming this is your namespace

namespace PrimeFactorTests
{
    [TestClass]
    public class Test2
    {
        [TestMethod]
        public void TestFactorsOf1000()
        {
            string result = PrimeCalculator.PrimeFactors(1000);
            Assert.AreEqual("2 x 2 x 2 x 5 x 5 x 5", result);
        }
    }
}
