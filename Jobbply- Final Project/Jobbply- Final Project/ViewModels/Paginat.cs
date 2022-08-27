using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class Paginat<T>
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public List<T> Items { get; set; }
        public Paginat(int pagecount, int cuurentpage, List<T> items)
        {
            PageCount = pagecount;
            CurrentPage = cuurentpage;
            Items = items;
        }
    }
}
