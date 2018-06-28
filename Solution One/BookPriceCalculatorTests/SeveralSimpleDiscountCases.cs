using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace BookPriceCalculatorTests
{
    [TestClass]
    public class SeveralSimpleDiscountCases
    {
        [TestMethod]
        public void GetPrice_2BooksSame1BookDifferent_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    1, 2, 2
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 + (8 * 2 * .95), totalPrice);
        }

        [TestMethod]
        public void GetPrice_2SetsOf2BooksSame_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    1, 2, 2, 1
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(2 * (8 * 2 * .95), totalPrice);
        }

        [TestMethod]
        public void GetPrice_2SetsOf2BooksSame2BooksDifferent_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0, 0, 1, 2, 2, 3
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual((8 * 4 * 0.8) + (8 * 2 * 0.95), totalPrice,
                "Total was supposed to be " + ((8 * 4 * 0.8) + (8 * 2 * 0.95)) + "but was " + totalPrice);
        }

        [TestMethod]
        public void GetPrice_2BooksSame4BooksDifferent_ReturnsSpecialDiscount()
        {
            //Arrange
            int[] cart =
            {
                    0, 1, 1, 2, 3, 4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 + (8 * 5 * 0.75), totalPrice,
                "Total was supposed to be " + (8 + (8 * 5 * 0.75)) + "but was " + totalPrice);
        }
    }
}
