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

        [TestMethod]
        public void 第一集買了一本第二集也買了一本()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
            };

            var expect = 190;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void 一二三集各買了一本()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
            };

            var expect = 270;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void 一二三四集各買了一本()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
                new Book() { Name = "Harry Potter Vol.4", Volume = 4, Price = 100 },
            };

            var expect = 320;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void 一次買了整套一二三四五集各買了一本()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
                new Book() { Name = "Harry Potter Vol.4", Volume = 4, Price = 100 },
                new Book() { Name = "Harry Potter Vol.5", Volume = 5, Price = 100 },
            };

            var expect = 375;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void 一二集各買了一本第三集買了兩本()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
            };

            var expect = 370;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void 第一集買了一本第二三集各買了兩本()
        {
            //Arrange
            var order = new List<Book>()
            {
                new Book() { Name = "Harry Potter Vol.1", Volume = 1, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
                new Book() { Name = "Harry Potter Vol.2", Volume = 2, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
                new Book() { Name = "Harry Potter Vol.3", Volume = 3, Price = 100 },
            };

            var expect = 460;

            //Act
            var actual = new BookPricing().CalculatePrice(order);

            //Assert
            Assert.AreEqual(expect, actual);
        }
    }
}
