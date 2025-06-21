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
