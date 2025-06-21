## `ECommerceSearch.cs`:
```csharp
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
```

## Output:
```
[*] Linear Search (unsorted):
Found: 150: Laptop (Electronics)

[*] Binary Search (sorted):
Found: 150: Laptop (Electronics)
```

<hr>

## `FactoryMethodDemo.cs`:
```csharp
using System;

// Step 2: Define abstract base class
abstract class Document {
    public abstract void Open();
}

// Step 3: Concrete document classes
class WordDocument : Document {
    public override void Open() {
        Console.WriteLine("Opening a Word document.");
    }
}

class PdfDocument : Document {
    public override void Open() {
        Console.WriteLine("Opening a PDF document.");
    }
}

class ExcelDocument : Document {
    public override void Open() {
        Console.WriteLine("Opening an Excel document.");
    }
}

// Step 4: Factory abstract class
abstract class DocumentFactory {
    public abstract Document CreateDocument();
}

// Step 4: Concrete factories
class WordDocumentFactory : DocumentFactory {
    public override Document CreateDocument() {
        return new WordDocument();
    }
}

class PdfDocumentFactory : DocumentFactory {
    public override Document CreateDocument() {
        return new PdfDocument();
    }
}

class ExcelDocumentFactory : DocumentFactory {
    public override Document CreateDocument() {
        return new ExcelDocument();
    }
}


// Step 5: Test class
class FactoryMethodDemo {
    public static void Main() {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document word = wordFactory.CreateDocument();
        word.Open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdf = pdfFactory.CreateDocument();
        pdf.Open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excel = excelFactory.CreateDocument();
        excel.Open();
    }
}
```

## Output:
```
Opening a Word document.
Opening a PDF document.
Opening an Excel document.
```

<hr>

## `FinancialForecasting.cs`:
```csharp
using System;
using System.Collections.Generic;

class FinancialForecasting {
    // Recursive method to compute future value
    public static double PredictFutureValue(double principal, double growthRate, int years) {
        if (years == 0)
            return principal;
        return PredictFutureValue(principal, growthRate, years - 1) * (1 + growthRate);
    }

    // Optimized version using memoization
    public static double PredictFutureValueMemo(double principal, double growthRate, int years, Dictionary<int, double> memo) {
        if (years == 0)
            return principal;

        if (memo.ContainsKey(years))
            return memo[years];

        double prev = PredictFutureValueMemo(principal, growthRate, years - 1, memo);
        double result = prev * (1 + growthRate);
        memo[years] = result;
        return result;
    }

    public static void Main() {
        double principal = 1000.0;
        double growthRate = 0.05; // 5% annual growth
        int years = 10;

        Console.WriteLine("[*] Basic Recursive Forecast:");
        double value = PredictFutureValue(principal, growthRate, years);
        Console.WriteLine($"After {years} years: ${value:F2}");

        Console.WriteLine("\n[*] Optimized Recursive Forecast with Memoization:");
        var memo = new Dictionary<int, double>();
        double memoValue = PredictFutureValueMemo(principal, growthRate, years, memo);
        Console.WriteLine($"After {years} years: ${memoValue:F2}");
    }
}
```

## Output:
```
[*] Basic Recursive Forecast:
After 10 years: $1628.89

[*] Optimized Recursive Forecast with Memoization:
After 10 years: $1628.89
```

<hr>

## `SingletonDemo.cs`:
```csharp
using System;

class Logger {
    private static Logger _instance;
    private static readonly object _lock = new object();

    // Private constructor to prevent external instantiation
    private Logger() {
        Console.WriteLine("Logger created");
    }

    // Public static method to get the single instance
    public static Logger GetInstance() {
        if (_instance == null) {
            lock (_lock) // Thread-safe lazy initialization
            {
                if (_instance == null) {
                    _instance = new Logger();
                }
            }
        }

        return _instance;
    }

    public void Log(string message) {
        Console.WriteLine($"[LOG]: {message}");
    }
}


class SingletonDemo {
    public static void Main() {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("Hello from logger1");
        logger2.Log("Hello from logger2");

        Console.WriteLine($"Same instance? {object.ReferenceEquals(logger1, logger2)}");
    }
}
```

## Output:
```
Logger created
[LOG]: Hello from logger1
[LOG]: Hello from logger2
Same instance? True
```

<hr>

