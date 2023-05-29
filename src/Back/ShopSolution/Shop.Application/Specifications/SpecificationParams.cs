namespace Shop.Application.Specifications;

public abstract class SpecificationParams
{
    private const int maxPageSize = 50;
    private int pageSize = 3;

    public string? Sort { get; set; }
    public int PAgeIndex { get; set; } = 1;

    public int PageSize
    {
        get => pageSize;
        set => pageSize = (value > maxPageSize) ? maxPageSize : value;
    }

    public string? Search { get; set; }
}