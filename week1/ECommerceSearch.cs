using System;

class Product : IComparable<Product> {
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category) {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public int CompareTo(Product other) {
        return this.ProductId.CompareTo(other.ProductId);
    }

    public override string ToString() {
        return $"{ProductId}: {ProductName} ({Category})";
    }
}

class ECommerceSearch {
    // Linear search: O(n)
    public static Product LinearSearch(Product[] products, int targetId) {
        foreach (var product in products) {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

    // Binary search: O(log n) (array must be sorted by ProductId)
    public static Product BinarySearch(Product[] products, int targetId) {
        int left = 0, right = products.Length - 1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (products[mid].ProductId == targetId)
                return products[mid];
            else if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }

    public static void Main() {
        // Unsorted for linear search
        Product[] unsortedProducts = new Product[]
        {
            new Product(101, "Mouse", "Electronics"),
            new Product(205, "Shirt", "Clothing"),
            new Product(150, "Laptop", "Electronics"),
            new Product(300, "Notebook", "Stationery")
        };

        Console.WriteLine("[*] Linear Search (unsorted):");
        var linearResult = LinearSearch(unsortedProducts, 150);
        Console.WriteLine(linearResult != null ? $"Found: {linearResult}" : "Product not found");

        // Sorted array for binary search
        Product[] sortedProducts = (Product[])unsortedProducts.Clone();
        Array.Sort(sortedProducts); // sort by ProductId

        Console.WriteLine("\n[*] Binary Search (sorted):");
        var binaryResult = BinarySearch(sortedProducts, 150);
        Console.WriteLine(binaryResult != null ? $"Found: {binaryResult}" : "Product not found");
    }
}
