using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cafe;

namespace _01_cafe_tests
{
    [TestClass]
    public class CafeRepoTests
    {
        //add
        [TestMethod]
        public void SetItemName_shouldSetCorrectString()
        {
            //arrange --> Setting up the playing field
            MenuItem item = new MenuItem();
            item.ItemName = "Fireside Chili";
            //act -->get run the code
            Cafe_Repo cafe = new Cafe_Repo();
            cafe.CreateItem(item);
            //MenuItem ItemFromMenu = cafe.("Fireside Chili");
           // Assert.IsNotNull(ItemFromMenu);//
        }
    }
}
