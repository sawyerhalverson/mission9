using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.ViewModels
{
    public class PageInfo
    {
        //keep track of pages and other info
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //figure out num required pages
        public int TotalPages => (int) Math.Ceiling(((double)TotalNumBooks / BooksPerPage));
    }
}
