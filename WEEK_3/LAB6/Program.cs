using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            // Update a Product
            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (product != null)
            {
                product.Price = 70000;
                await context.SaveChangesAsync();
                Console.WriteLine("Product price updated.");
            }

            // Delete a Product
            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            if (toDelete != null)
            {
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                Console.WriteLine("Product deleted.");
            }
        }
    }
}
