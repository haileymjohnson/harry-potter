using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace BookPriceCalculatorTests
{
    [TestClass]
    public class SimpleCases
    {
        [TestMethod]
        public void GetPrice_ArrayHasZeroValues_Returns0()
        {
            //Arrange
            int[] cart = { };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(0, totalPrice);
        }

        [TestMethod]
        public void GetPrice_OneValue_ReturnsPriceOfThatBook()
        {
            //Arrange
            int[] cart =
            {
                    1
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8, totalPrice);
        }

        [TestMethod]
        public void GetPrice_TwoValuesOfSameBook_ReturnsSumofPrices()
        {
            //Arrange
            int[] cart =
            {
                    1, 1
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 2, totalPrice);
        }

        [TestMethod]
        public void GetPrice_ThreeValuesOfSameBook_ReturnsSumofPrices()
        {
            //Arrange
            int[] cart =
            {
                    1, 1, 1
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 3, totalPrice);
        }

        [TestMethod]
        public void GetPrice_FourValuesOfSameBook_ReturnsSumofPrices()
        {
            //Arrange
            int[] cart =
            {
                    1, 1, 1, 1
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 4, totalPrice);
        }

        [TestMethod]
        public void GetPrice_FiveValuesOfSameBook_ReturnsSumofPrices()
        {
            //Arrange
            int[] cart =
            {
                    1, 1, 1, 1, 1
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 5, totalPrice);
        }
    }
}
