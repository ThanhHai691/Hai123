namespace hai123.Extensions;

public class Pagination
{
    public List<object> Data { get; set; }
    public object Page { get; set; }
    public object PageSize { get; set; }
    public int Total { get; set; }
}
public class ParamQuery
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? Search { get; set; }
}