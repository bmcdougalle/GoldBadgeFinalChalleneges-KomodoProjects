using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cafe;

namespace _01_cafe_tests
{
    [TestClass]
    public class CafeRepoTests
    {
        private MenuItem _item;
        private Cafe_Repo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new Cafe_Repo();
            _item = new MenuItem();
        }
        //add
        [TestMethod]
        public void AddToMenuList_ShouldGetNotNUll()
        {
            //arrange --> Setting up the playing field
            MenuItem item = new MenuItem();
            item.ItemNumber = 4;
            Cafe_Repo cafe = new Cafe_Repo();
          
            //act -->get run the code
            cafe.CreateItem(item);
            MenuItem itemFromDirectory = cafe.GetItem(4);

            Assert.IsNotNull(itemFromDirectory);
        }


        [TestMethod]
        public void TestReadMethod()
        {
            MenuItem menu = new MenuItem();
            Cafe_Repo cafe = new Cafe_Repo();

            cafe.GetMenuItems();

        }



        [TestMethod]
        public void TestUpdateMethod()
        {

        }
    }
}
