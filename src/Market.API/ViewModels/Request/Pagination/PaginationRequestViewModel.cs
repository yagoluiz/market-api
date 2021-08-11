namespace Market.API.ViewModels.Request.Pagination
{
    public class PaginationRequestViewModel
    {
        /// <summary>
        ///     Pagination page
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        ///     Pagination limit
        /// </summary>
        public int Limit { get; set; } = 30;
    }
}
