using System;
using System.Collections.Generic;

/*
Exercise 7: Financial Forecasting

Scenario: 
You are developing a financial forecasting tool that predicts future values based on past data.

1. Understand Recursive Algorithms:
   - Recursion is when a function calls itself to solve smaller subproblems until a base case is reached.
   - While recursion is elegant, it can be inefficient due to repeated calculations (O(2^n) time).
   - Dynamic Programming (DP) improves this using:
     a. Memoization (Top-down with cache)
     b. Tabulation (Bottom-up iteration, better space-wise)

2. Mathematical Background:
   - Compound Interest (CI) = P(1 + r)^n
   - Simple Interest (SI) = P × r × t
   - Effective Annual Rate from Nominal = (1 + r/n)^n - 1
   - Where:
     * P = principal or current value
     * r = rate of interest
     * n = number of years (or compounding periods)

4. Complexity:
   - Recursion: Time O(2^n), Space O(n)
   - Memoization: Time O(n), Space O(n)
   - Tabulation: Time O(n), Space O(n)
*/

class FinancialForecast
{
    // Recursive approach without optimization: O(2^n)
    public static double Recursion(double currval, double rate, int years)
    {
        if (years == 0)
            return currval;
        return Recursion(currval, rate, years - 1) * (1 + rate);
    }

    // Memoization approach: stores already-computed results (Top-down DP)
    public static double Memoization(double currval, double rate, int years, Dictionary<int, double> memo)
    {
        if (years == 0)
            return currval;
        if (memo.ContainsKey(years))
            return memo[years];
        double result = Memoization(currval, rate, years - 1, memo) * (1 + rate);
        memo[years] = result;
        return result;
    }

    // Tabulation approach: builds solution iteratively from bottom-up
    public static double Tabulation(double currval, double rate, int years)
    {
        double[] dp = new double[years + 1];
        dp[0] = currval;
        for (int i = 1; i <= years; i++)
        {
            dp[i] = dp[i - 1] * (1 + rate);
        }
        return dp[years];
    }

    // Simple Interest calculation
    public static double SimpleInterest(double currval, double rate, int years)
    {
        return currval + (currval * rate * years);
    }

    // Converts nominal rate to effective annual rate
    public static double EffectiveFromNominal(double nominal, int compPerYear)
    {
        return Math.Pow(1 + nominal / compPerYear, compPerYear) - 1;
    }

    static void Main()
    {
        Console.Write("Enter principal value: ");
        double initial = double.Parse(Console.ReadLine()!);

        Console.Write("Enter number of years: ");
        int years = int.Parse(Console.ReadLine()!);

        Console.Write("Do you have Nominal or Effective rate? (Enter N or E): ");
        string type = Console.ReadLine()!;

        double rate = 0.0;

        // Determine rate based on user input
        if (type.Equals("N", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter Nominal annual rate (e.g., 0.06 for 6%): ");
            double nominal = double.Parse(Console.ReadLine()!);

            Console.Write("Enter compounding periods per year (e.g., 12): ");
            int n = int.Parse(Console.ReadLine()!);

            rate = EffectiveFromNominal(nominal, n);
            Console.WriteLine($"Calculated Effective Annual Rate: {rate:F5}");
        }
        else if (type.Equals("E", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter Effective annual rate (e.g., 0.0617): ");
            rate = double.Parse(Console.ReadLine()!);
        }
        else
        {
            Console.WriteLine("Invalid input for rate type.");
            return;
        }

        // Future value using recursion
        double resultRecursive = Recursion(initial, rate, years);
        Console.WriteLine($"Future value (Recursion): {resultRecursive}");

        // Future value using memoization
        Dictionary<int, double> memo = new Dictionary<int, double>();
        double resultMemo = Memoization(initial, rate, years, memo);
        Console.WriteLine($"Future value (Memoization): {resultMemo}");

        // Future value using tabulation
        double resultTabulation = Tabulation(initial, rate, years);
        Console.WriteLine($"Future value (Tabulation): {resultTabulation}");

        // Simple interest output
        Console.WriteLine($"Simple Interest: {SimpleInterest(initial, rate, years)}");
    }
}
