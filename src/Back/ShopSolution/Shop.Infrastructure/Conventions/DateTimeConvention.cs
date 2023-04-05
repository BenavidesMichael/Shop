using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Conventions;
public static class DateTimeConvention
{
    public static void Convert(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
    }
}