namespace ClubManager.Application.Common;
public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Total { get; set; }
    public int PageSize { get; set; }
    public int PageNo { get; set; }
    public int TotalPages { get; set; }

    public PagedResult(IEnumerable<T> items, int total, int pageSize, int pageNo)
    {
        Items = items;
        Total = total;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(total / (double)pageSize);
    }
}
