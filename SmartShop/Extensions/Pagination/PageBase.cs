using System;

namespace SmartShop.Extensions.Pagination
{
    public abstract class PageBase
    {
        public int TotalRecord { get; set; }

        public int PageCurrent { get; set; }

        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecord / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set { PageCount = value; }
        }
    }
}