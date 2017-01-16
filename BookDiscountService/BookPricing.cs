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

            total = total * GetDiscount(books) / 100;

            return total;
        }

        private int GetDiscount(IEnumerable<Book> books)
        {
            int differntVolumes = books.GroupBy(x => x.Volume).Count();

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
