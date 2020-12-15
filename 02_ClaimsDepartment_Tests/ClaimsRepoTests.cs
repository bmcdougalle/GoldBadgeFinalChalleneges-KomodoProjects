using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClaimsDepartment;
using System;

namespace _02_ClaimsDepartment_Tests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private Claims _claim;
        private Claims_repo _claims_Repo;

        [TestInitialize]
        public void Helper()
        {
            _claim = new Claims(1, ClaimType.Car, "Collision: font end damage", 5000.00m, DateTime.Parse("2020 / 02 / 05"), DateTime.Parse("2020 / 02 / 27"), true);
            _claims_Repo = new Claims_repo();
            _claims_Repo.AddAClaim(_claim);
        }

        [TestMethod]
        public void TestAddMethod_ShouldGetNotNull()
        {
            //arrange
            Claims claim = new Claims();
            claim.ClaimID = 10;
            Claims_repo claims_Repo = new Claims_repo();

            //act
            claims_Repo.AddAClaim(claim);
            Claims claimFromQueue = claims_Repo.GetClaimByID(10);

            //assert
            Assert.IsNotNull(claimFromQueue);

        }
        [TestMethod]
        public void TestReadMethod_ShouldGetNotNUll()
        {
            Claims claim = new Claims();
            Claims_repo claims_Repo = new Claims_repo();
            claims_Repo.ViewClaims();

            Assert.IsNotNull(claim);
        }
        [TestMethod]
        public void TestUpdateMethod_ShouldReturnTrue()
        {
            Claims newClaim = new Claims(1, ClaimType.Car, "Smash: font end damage", 5000.00m, DateTime.Parse("2020 / 02 / 05"), DateTime.Parse("2020 / 02 / 27"), true);
            bool shouldupdate = _claims_Repo.UpdateClaim(1, newClaim);

            Assert.IsTrue(shouldupdate);
        }
        [TestMethod]
        public void TestDeleteMethod_ShouldReturnTrue()
        {
            bool deleteResult = _claims_Repo.RemoveClaim(_claim.ClaimID);
            Assert.IsTrue(deleteResult);
        }
        [TestMethod]
        public void TestHelperMethod_ShouldGetNotNUll()
        {
            Claims claim = new Claims(1, ClaimType.Car, "Collision: font end damage", 5000.00m, DateTime.Parse("2020 / 02 / 05"), DateTime.Parse("2020 / 02 / 27"), true);
            _claims_Repo.GetClaimByID(1);

            Assert.IsNotNull(claim);
        }
    }
}
