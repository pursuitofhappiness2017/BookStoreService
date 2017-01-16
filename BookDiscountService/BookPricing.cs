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
            int total = books.Sum(x => x.Price);

            if (books.GroupBy(x => x.Volume).Count() > 1)
            {
                total = total * 95 / 100;
            }

            return total;
        }
    }

    public class Book
    {
        public string Name { get; set; }

        public int Volume { get; set; }

        public int Price { get; set; }
    }
}
