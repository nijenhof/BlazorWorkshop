namespace BlazorWorkshop.Shared
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse(int currentPage, int currentPageSize, int totalItems, List<T> items)
        {
            CurrentPage = currentPage;
            CurrentPageSize = currentPageSize;
            Items = items;
            TotalItems = totalItems;
        }

        public int CurrentPage { get; set; }
        public int CurrentPageSize { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; } = new();
    }
}
