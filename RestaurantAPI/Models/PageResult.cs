using System;
using System.Collections.Generic;

namespace RestaurantAPI.Models
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemFrom { get; set; }
        public int ItemTo { get; set; }
        public int TotalItemsCount { get; set; }
        public PageResult(List<T> items, int totalCount, int pageSize, int pageNumber)
        {
            this.Items = items;
            this.TotalItemsCount = totalCount;
            this.ItemFrom = pageSize * (pageNumber - 1) + 1;
            this.ItemTo = this.ItemFrom + pageSize - 1;
            this.TotalPages = (int)Math.Ceiling(totalCount /(double) pageSize);
        }
    }
}
