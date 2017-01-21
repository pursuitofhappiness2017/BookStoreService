using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreService
{
    public class BookPricing
    {
        public int CalculatePrice(IEnumerable<Book> books)
        {
            int total = 0;

            if (books.Any())
            {
                var bookSet = GetBookSet(books);

                if (bookSet.Count() == 1)
                {
                    return books.Sum(x => x.Price);
                }

                var discount = GetDiscount(bookSet.Count());

                total += bookSet.Sum(x => x.Price) * discount / 100;

                total += CalculatePrice(books.Except(bookSet));
            }

            return total;
        }

        private IEnumerable<Book> GetBookSet(IEnumerable<Book> books)
        {
            var set = books.GroupBy(x => x.Volume).Select(x => x.First());

            return set;
        }

        private int GetDiscount(int differntVolumes)
        {
            Dictionary<int, int> discount = new Dictionary<int, int>()
            {
                { 1, 100},
                { 2, 95},
                { 3, 90},
                { 4, 80},
                { 5, 75},
            };

            int max = discount.Keys.Max();

            if (differntVolumes > max)
            {
                return discount[max];
            }

            return discount[differntVolumes];
        }
    }

    public class Book
    {
        public string Name { get; set; }

        public int Volume { get; set; }

        public int Price { get; set; }
    }
}
