using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cafe;
using System.Collections.Generic;

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
            _item = new MenuItem(1, "Hot Coffee", "Medium Roast Coffee with your choice of creamer", 0.55,
                new List<string>() { "medium roast coffee grounds", "your choice of creamer" });
            _repo.CreateItem(_item);
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
            List<MenuItem> menuItems = cafe.GetMenuItems();

            bool iscorrect = false;
            foreach(MenuItem menuItem in menuItems)
            {
                if(menuItem.ItemNumber == item.ItemNumber)
                {
                    iscorrect = true;
                    break;
                }
            }

            Assert.IsTrue(iscorrect);
        }


        [TestMethod]
        public void TestReadMethod()
        {

            MenuItem menu = new MenuItem();
            Cafe_Repo cafe = new Cafe_Repo();

           List<MenuItem> menuItems = cafe.GetMenuItems();

            Assert.IsNotNull(menuItems);
        }



        [TestMethod]
        public void TestUpdateMethod_ShouldReturnTrue()
        {
            //arrange
            //TestInitialize
            MenuItem newItem = new MenuItem(1,"Hot Coffee3", "Medium Roast Coffee with your choice of creamer", 0.55,
                new List<string>() { "medium roast coffee grounds", "your choice of creamer" });
            //act
            bool updateResult = _repo.UpdateMenuItems(1, newItem);

            //assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void TestGetItemBYID_ShouldReturnNOtNUll()
        {
            //arrange
            MenuItem item = new MenuItem(1, "Hot Coffee", "Medium Roast Coffee with your choice of creamer", 0.55,
                new List<string>() { "medium roast coffee grounds", "your choice of creamer" });
             _repo.GetItem(1);
            //TestInitialize

            ///act
            MenuItem menuItem = _repo.GetItem(1);
            //assert
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void TestDeleteMethod_ShouldReturntrue()
        {
            //arrange

            //act
            bool deleteResult = _repo.DeleteItems(_item.ItemNumber);

            //assert
            Assert.IsTrue(deleteResult);
        }
    }
}
