namespace igdPropiedadHorizontal.Application.Configuration.Pagination;

public class PageList<T> where T : class
{
    public int Page { get; private set; }
    public int PageSize { get; private set; }
    public int TotalItems { get; private set; }
    public int TotalPage { get; private set; }
    public string NextPage { get; private set; }
    public string PreviusPage { get; private set; }
    public string URL { get; private set; }
    public bool Succeeded { get; private set; } = true;
    public string Message { get; set; } = "Succeeded";

    public List<T> Items { get; private set; }

    public PageList(List<T> items, int page, int pageSize, int totalItems, string url)
    {
        Page = page;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPage = PageSize != 0 ? (int)Math.Ceiling(TotalItems / (double)PageSize) : 0;
        URL = url;

        if (page > 1)
            PreviusPage = $"{URL}?page={page - 1}&pageSize={pageSize}";

        if (page < TotalPage)
            NextPage = $"{URL}?page={page + 1}&pageSize={pageSize}";


        if (page < 1)
            NextPage = $"{URL}?page=1&pageSize={pageSize}";


        Items = items;


        if (page < 1 || page > TotalPage)
        {
            Succeeded = false;
            Message = $"The page number must be between 1 and {TotalPage}.";
            ClearResult();
        }

        if (pageSize <= 0)
        {
            Succeeded = false;

            Message = Message != "" ? Message += "The page size must be greater than 0" : "The page size must be greater than 0";
            ClearResult();
        }


    }

    private void ClearResult()
    {
        Items.Clear();
        Page = 0;
        PageSize = 0;
        TotalPage = 0;
        NextPage = null;
        PreviusPage = null;
        URL = null;
    }
}
