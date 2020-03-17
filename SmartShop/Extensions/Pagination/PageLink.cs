namespace SmartShop.Extensions.Pagination
{
    public class PageLink
    {
        public PageLink() {  }

        public PageLink(int pageStart, int pageEnd, int pageLast, int pageNext, int pageCount) 
        {
            PageStart = pageStart;
            PageEnd = pageEnd;
            PageNext = pageNext;
            PageLast = pageLast;
            PageCount = pageCount;
        }

        public int PageStart { get; set; }

        public int PageEnd { get; set; }

        public int PageLast { get; set; }

        public int PageNext { get; set; }

        public int PageCount { get; set; }

        public int PageCurrent { get; set; }
    }
}