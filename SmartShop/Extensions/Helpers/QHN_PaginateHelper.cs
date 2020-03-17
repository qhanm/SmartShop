using SmartShop.Extensions.Pagination;

namespace SmartShop.Extensions.Helpers
{
    public class QHN_PaginateHelper
    {
        public static PageLink CalculatorPagiante(int pageCurrent, int pageCount)
        {
            int pageStart = 0, pageEnd = 0, pageLast = 0, pageNext = 0;

            // calculator page start
            pageStart = pageCurrent - 2;
            if (pageStart <= 1) 
            {
                pageStart = 1;
                pageEnd = (pageStart + 4 > pageCount) ? pageCount : pageStart + 4;
            }

            // calculator page end
            if(pageEnd == 0)
            {
                pageEnd = pageCurrent + 2;
                if (pageEnd > pageCount) 
                {
                    pageEnd = pageCount;
                    pageStart = (pageEnd - 4 <= 1) ? 1 : pageEnd - 4;
                }
            }



            // calculator page last
            pageLast = pageCurrent - 1;
            if (pageLast <= 0) { pageLast = 1; }

            // calculator page next
            pageNext = pageCurrent + 1;
            if (pageNext > pageCount) { pageNext = pageCount; }

            return new PageLink()
            {
                PageStart = pageStart,
                PageEnd = pageEnd,
                PageLast = pageLast,
                PageNext = pageNext,
                PageCount = pageCount,
                PageCurrent = pageCurrent,
            };
        }
    }
}