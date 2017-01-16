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
            if(differntVolumes > 4)
            {
                return 75; 
            }

            switch (differntVolumes)
            {
                case 4:
                    return 80;
                case 3:
                    return 90;
                case 2:
                    return 95;
                case 1:
                default:
                    return 100;
            }
        }
    }

    public class Book
    {
        public string Name { get; set; }

        public int Volume { get; set; }

        public int Price { get; set; }
    }
}
