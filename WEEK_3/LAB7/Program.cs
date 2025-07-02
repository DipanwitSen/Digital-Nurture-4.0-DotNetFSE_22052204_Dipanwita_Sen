using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            // Filter and Sort
            var filtered = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            Console.WriteLine("Filtered and Sorted Products:");
            foreach (var p in filtered)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price}");
            }

            // Project into DTO (Anonymous Object)
            var productDTOs = await context.Products
                .Select(p => new { p.Name, p.Price })
                .ToListAsync();

            Console.WriteLine("\nProduct DTOs:");
            foreach (var p in productDTOs)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price}");
            }
        }
    }
}
