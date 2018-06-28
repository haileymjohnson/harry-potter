using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BookPriceCalculator
    {
        private List<int> optCart;
        private double fiveDiscount = .75;
        private double fourDiscount = .8;
        private double threeDiscount = .9;
        private double twoDiscount = .95;
        private double singleBookPrice = 8.0;
        private int maxNumberOfDistinctBooks = 5;

        public BookPriceCalculator(int[] cart)
        {
            optCart = GetOptimizedCart(cart);
        }

        private List<int> GetOptimizedCart(int[] cart)
        {
            var booksInSets = new List<int>();
            if (cart.Count() == 0)
            {
                booksInSets = null;
            }
            else
            {
                var numberOfBooksInEachBookTypeSetList = GetNumberOfBooksOfEachTypeList(cart);
                booksInSets = PutBooksInSets(numberOfBooksInEachBookTypeSetList);
            }

            return booksInSets;
        }

        private List<int> PutBooksInSets(List<int> numberOfBooksInEachBookTypeSetList)
        {
            var maxNumberOfSets = numberOfBooksInEachBookTypeSetList.Max();
            List<int> sets = new List<int>();
            for (int i = 0; i <= (maxNumberOfSets - 1); i++)
            {
                sets.Add(numberOfBooksInEachBookTypeSetList.Count(n => n >= 1));
                numberOfBooksInEachBookTypeSetList = DecrementBookList(numberOfBooksInEachBookTypeSetList);
            }
            sets = OptimizeSets(sets);
            return sets;
        }

        private List<int> OptimizeSets(List<int> sets)
        {
            while (sets.Contains(maxNumberOfDistinctBooks))
            {
                if (sets.Contains(maxNumberOfDistinctBooks - 2))
                {
                    sets.Remove(maxNumberOfDistinctBooks);
                    sets.Remove(maxNumberOfDistinctBooks - 2);
                    sets.Add(maxNumberOfDistinctBooks - 1);
                    sets.Add(maxNumberOfDistinctBooks - 1);
                }
                else
                {
                    break;
                }
            }
            return sets;
        }

        private List<int> DecrementBookList(List<int> numberOfBooksInEachBookTypeSetList)
        {
            for (int i = 0; i <= (numberOfBooksInEachBookTypeSetList.Count - 1); i++)
            {
                numberOfBooksInEachBookTypeSetList[i]--;
            }
            return numberOfBooksInEachBookTypeSetList;
        }

        private List<int> GetNumberOfBooksOfEachTypeList(int[] cart)
        {
            var numberOfBooksInEachBookTypeSetList = new List<int>();
            IEnumerable<int> distinctBooks = cart.Distinct();
            foreach (int book in distinctBooks)
            {
                numberOfBooksInEachBookTypeSetList.Add(cart.Count(b => b.Equals(book)));
            }
            return numberOfBooksInEachBookTypeSetList;
        }

        public double GetPrice()
        {
            var price = 0.0;
            if (optCart == null)
            {
                price = 0;
            }
            else
            {
                foreach (int setNumber in optCart)
                {
                    var discount = getDiscount(setNumber);
                    price += singleBookPrice * discount * setNumber;
                }
            }
            return price;
        }

        private double getDiscount(int count)
        {
            var discount = 1.0;

            if (count == 5)
            {
                discount = fiveDiscount;
            }
            else if (count == 4)
            {
                discount = fourDiscount;
            }
            else if (count == 3)
            {
                discount = threeDiscount;
            }
            else if (count == 2)
            {
                discount = twoDiscount;
            }

            return discount;
        }
    }
}
