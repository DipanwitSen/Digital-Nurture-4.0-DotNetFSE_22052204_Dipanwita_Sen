
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

class Product {
    int product_id;
    String product_name;
    String Category;

    public Product(int product_id, String product_name, String Category) {
        this.product_id = product_id;
        this.product_name = product_name;
        this.Category = Category;
    }
}

public class ECommerceSearch {
    public static Product linearSearch(Product[] products, int target) {
        for (Product p : products) {
            if (p.product_id == target) {
                return p;
            }
        }
        return null;
    }

    public static Product binarySearch(Product[] products, int target) {
        int left = 0, right = products.length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (products[mid].product_id == target)
                return products[mid];
            else if (products[mid].product_id < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter number of products: ");
        int n = sc.nextInt();
        sc.nextLine();

        Product[] p = new Product[n];
        for (int i = 0; i < n; i++) {
            System.out.println("\nEnter details for Product " + (i + 1));
            System.out.print("Product ID: ");
            int id = sc.nextInt();
            sc.nextLine();
            System.out.print("Product Name: ");
            String name = sc.nextLine();
            System.out.print("Category: ");
            String category = sc.nextLine();

            p[i] = new Product(id, name, category);
        }

        System.out.print("\nEnter Product ID to search: ");
        int target = sc.nextInt();

        System.out.println("\n Using Linear Search:");
        Product r1 = linearSearch(p, target);
        if (r1 != null)
            System.out.println("Found: " + r1.product_name + " in " + r1.Category);
        else
            System.out.println("Product not found.");

        Arrays.sort(p, Comparator.comparingInt(prod -> prod.product_id));
        System.out.println("\n Using Binary Search:");
        Product r2 = binarySearch(p, target);
        if (r2 != null)
            System.out.println(" Found: " + r2.product_name + " in " + r2.Category);
        else
            System.out.println(" Product not found.");

        sc.close();
    }
}
