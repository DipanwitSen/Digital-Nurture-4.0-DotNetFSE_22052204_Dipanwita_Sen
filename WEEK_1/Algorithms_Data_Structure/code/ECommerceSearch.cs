
/*Exercise 2: E-commerce Platform Search Function
Scenario: 
You are working on the search functionality of an e-commerce platform. The search needs to be optimized for fast performance.
Steps:
1.Understand Asymptotic Notation:
oExplain Big O notation and how it helps in analyzing algorithms.
oDescribe the best, average, and worst-case scenarios for search operations.
2.Setup:
oCreate a class Product with attributes for searching, such as productId, productName, and category.
3.Implementation:
oImplement linear search and binary search algorithms.
oStore products in an array for linear search and a sorted array for binary search.
4.Analysis:
oCompare the time complexity of linear and binary search algorithms.
oDiscuss which algorithm is more suitable for your platform and why. */
import java.util.*;

using System;
using System.Linq;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int productId, string productName, string category)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
    }
}

class ECommerceSearch
{
    public static Product LinearSearch(Product[] products, int target)
    {
        foreach (var p in products)
        {
            if (p.ProductId == target)
                return p;
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, int target)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (products[mid].ProductId == target)
                return products[mid];
            else if (products[mid].ProductId < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }

    static void Main()
    {
        Console.Write("Enter number of products: ");
        int n = int.Parse(Console.ReadLine());

        Product[] products = new Product[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Product {i + 1}");
            Console.Write("Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            products[i] = new Product(id, name, category);
        }

        Console.Write("\nEnter Product ID to search: ");
        int target = int.Parse(Console.ReadLine());

        Console.WriteLine("\nUsing Linear Search:");
        var result1 = LinearSearch(products, target);
        if (result1 != null)
            Console.WriteLine($"Found: {result1.ProductName} in {result1.Category}");
        else
            Console.WriteLine("Product not found.");

        Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

        Console.WriteLine("\nUsing Binary Search:");
        var result2 = BinarySearch(products, target);
        if (result2 != null)
            Console.WriteLine($"Found: {result2.ProductName} in {result2.Category}");
        else
            Console.WriteLine("Product not found.");
    }
}

