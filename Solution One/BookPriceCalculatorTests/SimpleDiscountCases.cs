using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace BookPriceCalculatorTests
{
    [TestClass]
    public class SimpleDiscountCases
    {
        [TestMethod]
        public void GetPrice_TwoValuesOfDifferentBook_ReturnsPriceWith5PercentDiscount()
        {
            //Arrange
            int[] cart =
            {
                    1, 2
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 2 * .95, totalPrice);
        }

        [TestMethod]
        public void GetPrice_ThreeValuesOfDifferentBook_ReturnsPriceWith10PercentDiscount()
        {
            //Arrange
            int[] cart =
            {
                    1, 2, 3
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 3 * .9, totalPrice);
        }

        [TestMethod]
        public void GetPrice_FourValuesOfDifferentBook_ReturnsPriceWith20PercentDiscount()
        {
            //Arrange
            int[] cart =
            {
                    1, 2, 3, 4
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 4 * .8, totalPrice);
        }

        [TestMethod]
        public void GetPrice_FiveValuesOfDifferentBook_ReturnsPriceWith25PercentDiscount()
        {
            //Arrange
            int[] cart =
            {
                    1, 2, 3, 4, 5
                };

            var bookPriceCalculator = new BookPriceCalculator(cart);

            //Action
            var totalPrice = bookPriceCalculator.GetPrice();

            //Assert
            Assert.AreEqual(8 * 5 * .75, totalPrice);
        }
    }
}
