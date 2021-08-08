using System;
using System.Collections.Generic;

namespace Market.Domain.Entities
{
    public class Pagination<T> : List<T>
    {
        public Pagination(
            IEnumerable<T> items,
            int count,
            int page,
            int limit
        )
        {
            Page = page;
            TotalPages = (int)Math.Ceiling(count / (double)limit);
            TotalItems = count;

            AddRange(items);
        }

        public int Page { get; }
        public int TotalPages { get; }
        public int TotalItems { get; }
    }
}