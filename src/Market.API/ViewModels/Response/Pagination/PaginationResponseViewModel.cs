using System.Collections.Generic;

namespace Market.API.ViewModels.Response.Pagination
{
    public class PaginationResponseViewModel<TResponseEntity>
    {
        public PaginationResponseViewModel(
            int page,
            int totalItems,
            int totalPages,
            IEnumerable<TResponseEntity> items
        )
        {
            Page = page;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Items = items;
        }

        /// <summary>
        ///     Current page
        /// </summary>
        public int Page { get; }

        /// <summary>
        ///     Total items
        /// </summary>
        public int TotalItems { get; }

        /// <summary>
        ///     Total pages
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        ///     Items
        /// </summary>
        public IEnumerable<TResponseEntity> Items { get; }
    }
}
