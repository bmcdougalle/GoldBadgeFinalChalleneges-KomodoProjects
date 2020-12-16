using _04_CompanyOutings_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _04_CompanyOutings_Tests
{
    [TestClass]
    public class CompanyOutingsRepoTests
    {
        //CompanyOutings _outings;
        //companyOutings_Repo _repo;
        //[TestInitialize]
        //public void Helper()
        //{

        //}
        [TestMethod]
        public void TestAddOutingMethod_ShouldGetNotNull()
        {
            CompanyOutings outing = new CompanyOutings();
            companyOutings_Repo outings_Repo = new companyOutings_Repo();

            outings_Repo.AddOuting(outing);
            CompanyOutings outingFromList = outings_Repo.GetOuting("1");

            Assert.IsNotNull(outingFromList);
        }


    }
}
