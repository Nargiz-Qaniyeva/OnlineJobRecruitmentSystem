using Jobbply__Final_Project.Models;
using System.Collections.Generic;

namespace Jobbply__Final_Project.ViewModels
{
    public class Pagination<T>
    {
        private int v;
        private int pageSize;
        private List<Worker> workers;

        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public List<T> Items { get; set; }
        public Pagination(int pageCount, int currentPage, List<T>items)
        {
            PageCount = pageCount;
            CurrentPage = currentPage;
            Items = items;
        }

        public Pagination(int v, int pageSize, List<Worker> workers)
        {
            this.v = v;
            this.pageSize = pageSize;
            this.workers = workers;
        }
    }
}
