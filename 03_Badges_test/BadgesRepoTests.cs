using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_Badges_Repo;
using System;

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
           _badge = new Badges(1, )
        }
        [TestMethod]
        public void TestAddBadgeToDict_ShouldReturnNotNull()
        {
            Badges badge = new Badges();
            badge.BadgeID = 1;
            Badges_Repo badges_Repo = new Badges_Repo();

            badges_Repo.AddBadgesToDict(badge);
            Badges badgesfromDict = badges_Repo.GetBadgeById(1);

            Assert.IsNotNull(badgesfromDict);

        }
        [TestMethod]
        public void TestReadMethod_ShouldReturnBadges()
        {
            Badges_Repo badges_Repo = new Badges_Repo();
            _repo.ShowAllBadges();



            Assert.IsNotNull();
        }
    }
}
   