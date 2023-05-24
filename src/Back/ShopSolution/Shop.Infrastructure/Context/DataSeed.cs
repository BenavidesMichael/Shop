using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Application.Models;
using Shop.Domain.Entities;
using System.Text.Json;

namespace Shop.Infrastructure.Context
{
    public class DataSeed
    {
        public static async Task LoadDataAsync(
            ShopDbContext shopDbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerFactory loggerFactory)
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(RoleAuth.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(RoleAuth.USER));
                }

                if (!userManager.Users.Any())
                {
                    var userMichael = new ApplicationUser()
                    {
                        UserName = "Mucha003",
                        Email = "Mucha003@gmail.com",
                        FirstName = "Michael",
                        LastName = "Benavides",
                        AvatarUrl = "https://gravatar.com/avatar/382932807a0673fda01a9ff9c1c0c5c8?s=400&d=robohash&r=x",
                    };

                    await userManager.CreateAsync(userMichael, "Michael_Benavides003$");
                    await userManager.AddToRoleAsync(userMichael, RoleAuth.ADMIN);

                    var userEthan = new ApplicationUser()
                    {
                        UserName = "FMI",
                        Email = "FMI@gmail.com",
                        FirstName = "Ethan",
                        LastName = "Hunt",
                        AvatarUrl = "https://gravatar.com/avatar/e83a6432e9ed8ea1a4509e9d854eb949?s=400&d=robohash&r=x",
                    };

                    await userManager.CreateAsync(userEthan, "Ethan_Hunt003$");
                    await userManager.AddToRoleAsync(userEthan, RoleAuth.USER);
                }

                if (!shopDbContext.Categories.Any())
                {
                    string? categories = File.ReadAllText("../Shop.Infrastructure/Data/category.json");
                    List<Category>? categoriesList = JsonSerializer.Deserialize<List<Category>>(categories);
                    await shopDbContext.Categories.AddRangeAsync(categoriesList!);
                    await shopDbContext.SaveChangesAsync();
                }

                if (!shopDbContext.Products.Any())
                {
                    string? products = File.ReadAllText("../Shop.Infrastructure/Data/product.json");
                    List<Product>? productsList = JsonSerializer.Deserialize<List<Product>>(products);
                    await shopDbContext.Products.AddRangeAsync(productsList!);
                    await shopDbContext.SaveChangesAsync();
                }

                if (!shopDbContext.Images.Any())
                {
                    string? images = File.ReadAllText("../Shop.Infrastructure/Data/image.json");
                    List<Image>? imagesList = JsonSerializer.Deserialize<List<Image>>(images);
                    await shopDbContext.Images.AddRangeAsync(imagesList!);
                    await shopDbContext.SaveChangesAsync();
                }

                if (!shopDbContext.Countries.Any())
                {
                    string? countries = File.ReadAllText("../Shop.Infrastructure/Data/countries.json");
                    List<Country>? countriesList = JsonSerializer.Deserialize<List<Country>>(countries);
                    await shopDbContext.Countries.AddRangeAsync(countriesList!);
                    await shopDbContext.SaveChangesAsync();
                }

                if (!shopDbContext.Reviews.Any())
                {
                    string? reviews = File.ReadAllText("../Shop.Infrastructure/Data/review.json");
                    List<Review>? reviewsList = JsonSerializer.Deserialize<List<Review>>(reviews);
                    await shopDbContext.Reviews.AddRangeAsync(reviewsList!);
                    await shopDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
