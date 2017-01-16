using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BookStoreService;

namespace UnitTestBookDiscount
{
    [TestClass]
    public class UnitTestBookPrice
    {
        [TestMethod]
        public void 第一集買了一本其他都沒買()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
            };

            var expect = 100;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }
    }
}
