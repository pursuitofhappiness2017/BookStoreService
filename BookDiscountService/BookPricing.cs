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

            int differntVolumes = books.GroupBy(x => x.Volume).Count();

            if (differntVolumes > 4)
            {
                total = total * 75 / 100;
            }
            else if (differntVolumes > 3)
            {
                total = total * 80 / 100;
            }
            else if (differntVolumes > 2)
            {
                total = total * 90 / 100;
            }
            else if (differntVolumes > 1)
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
