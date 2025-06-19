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
     * year = number of years (or compounding periods)
     * n=quarterly or half yearly 

4. Complexity:
   - Recursion: Time O(2^n), Space O(n)
   - Memoization: Time O(n), Space O(n)
   - Tabulation: Time O(n), Space O(n)
*/

class FinancialForecast
{
    // Recursive approach
    public static double Recursion(double currval, double rate, int years)
    {
        if (years == 0)
            return currval;
        return Recursion(currval, rate, years - 1) * (1 + rate);
    }

    // Memoization (Top-down DP)
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

    // Tabulation (Bottom-up DP)
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
    public static double SimpleInterest(double currval, double rate, double years)
    {
        return currval + (currval * rate * years);
    }

    // Convert Nominal % rate to Effective over total years (using compounding)
    public static double EffectiveFromNominal(double nominalPercent, int compPerYear, double years)
    {
        return Math.Pow(1 + (nominalPercent / (100 * compPerYear)), compPerYear * years) - 1;
    }

    static void Main()
    {
        Console.Write("Enter principal value: ");
        double initial = double.Parse(Console.ReadLine()!);

        Console.Write("Is the duration in (Y)ears or (M)onths? Enter Y or M: ");
        string durationType = Console.ReadLine()!;
        double years;

        if (durationType.Equals("M", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter number of months: ");
            int months = int.Parse(Console.ReadLine()!);
            years = months / 12.0;
        }
        else
        {
            Console.Write("Enter number of years: ");
            years = double.Parse(Console.ReadLine()!);
        }

        Console.Write("Do you have Nominal or Effective rate? (Enter N or E): ");
        string type = Console.ReadLine()!;
        double rate = 0.0;

        if (type.Equals("N", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter Nominal annual rate in % (e.g., 6 for 6%): ");
            double nominal = double.Parse(Console.ReadLine()!);

            Console.Write("Enter compounding periods per year (e.g., 4 for quarterly, 2 for half-yearly): ");
            int n = int.Parse(Console.ReadLine()!);

            rate = EffectiveFromNominal(nominal, n, years);
            Console.WriteLine($"Calculated Effective Rate over {years:F2} years: {rate:F5}");
        }
        else if (type.Equals("E", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter Effective rate for entire duration (e.g., 0.2610 for 26.1%): ");
            rate = double.Parse(Console.ReadLine()!);
        }
        else
        {
            Console.WriteLine("Invalid input for rate type.");
            return;
        }

        Console.WriteLine();

        int intYears = (int)Math.Round(years);

        double resultRecursive = Recursion(initial, rate, intYears);
        Console.WriteLine($"Future value (Recursion): {resultRecursive:F2}");

        Dictionary<int, double> memo = new Dictionary<int, double>();
        double resultMemo = Memoization(initial, rate, intYears, memo);
        Console.WriteLine($"Future value (Memoization): {resultMemo:F2}");

        double resultTabulation = Tabulation(initial, rate, intYears);
        Console.WriteLine($"Future value (Tabulation): {resultTabulation:F2}");

        Console.WriteLine($"Simple Interest: {SimpleInterest(initial, rate, years):F2}");
    }
}

       
