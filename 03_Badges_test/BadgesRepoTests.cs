using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_Badges_Repo;
using System;
using System.Collections.Generic;

namespace _03_Badges_test
{
    [TestClass]
    public class BadgesRepoTests
    {

        private Badges _badge;
        private Badges_Repo _repo;

        [TestInitialize]
        public void Helper()
        {
            _repo = new Badges_Repo();
            _badge = new Badges(30, new List<string> { "A1", "A@" });
            _repo.AddBadgesToDict(_badge);
        }

        [TestMethod]
        public void TestAddBadgeToDict_ShouldReturnNotNull()
        {
            Badges badge = new Badges(30007, new List<string> { "B777" });

            _repo.AddBadgesToDict(badge);
            int dictCount = _repo.ShowAllBadges().Count;

            Assert.AreEqual(2, dictCount);

        }
        [TestMethod]
        public void TestReadMethod_ShouldReturnBadges()
        {

            Dictionary<int, Badges> items = _repo.ShowAllBadges();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void TestUpdateBadges_ShouldReturnrtrue()
        {
            Badges newBadge = new Badges(507, new List<string> { "A5", "C202" });


            bool updateResult = _repo.UpdateBadges(1, newBadge);

            Console.WriteLine($"{newBadge.BadgeID}");
            foreach (var door in newBadge.Doors)
            {
                Console.WriteLine(door);
            }

            Assert.IsTrue(updateResult);


        }
    }
}
