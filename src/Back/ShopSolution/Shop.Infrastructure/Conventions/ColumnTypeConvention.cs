using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Conventions;
public static class ColumnTypeConvention
{
    public static void Convert(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(10,2)");
    }
}