using System.Collections.Generic;

namespace SmartShop.Extensions.Pagination
{
    public class PageResult<T> : PageBase where T : class
    {
        public PageResult()
        {
            Results = new List<T>();
            Link = new PageLink();
        }

        public IList<T> Results { get; set; }

        public PageLink Link { get; set; }
    }
}