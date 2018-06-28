using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace BookPriceCalculatorTests
{
    [TestClass]
    public class DiscountEdgeCases
    {
        [TestMethod]
        public void GetPrice_2Sets_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0, 0,
                    1, 1,
                    2, 2,
                    3,
                    4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(2 * (8 * 4 * 0.8), totalPrice);
        }

        [TestMethod]
        public void GetPrice_SpecialEdgeCase_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0, 0, 0, 0, 0,
                    1, 1, 1, 1, 1,
                    2, 2, 2, 2,
                    3, 3, 3, 3, 3,
                    4, 4, 4, 4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual((3 * (8 * 5 * 0.75)) + (2 * (8 * 4 * 0.8)), totalPrice);
        }

        [TestMethod]
        public void GetPrice_SpecialEdgeCase2_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0, 0, 0, 0, 0,
                    1, 1, 1, 1, 1,
                    2, 2, 2,
                    3, 3, 3, 3, 3,
                    4, 4, 4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual((8 * 5 * 0.75) + (4 * (8 * 4 * 0.8)), totalPrice);
        }

        [TestMethod]
        public void GetPrice_IncrementalBasket_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0,
                    1, 1,
                    2, 2, 2,
                    3, 3, 3, 3,
                    4, 4, 4, 4, 4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(100, totalPrice);
        }

        [TestMethod]
        public void GetPrice_Special_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0, 0, 0,
                    1, 1,
                    2, 2, 2, 2,
                    3, 3,
                    4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual((8 * 4 * 0.8) + (8 * 2 * 0.95) + 8 + (8 * 5 * .75), totalPrice);
        }
    }
}
