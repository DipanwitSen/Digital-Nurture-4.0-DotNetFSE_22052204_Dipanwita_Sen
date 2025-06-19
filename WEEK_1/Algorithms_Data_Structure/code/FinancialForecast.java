/*Exercise 7: Financial Forecasting
Scenario: 
You are developing a financial forecasting tool that predicts future values based on past data.
Steps:
1.Understand Recursive Algorithms:
oExplain the concept of recursion and how it can simplify certain problems.
2.Setup:
oCreate a method to calculate the future value using a recursive approach.
3.Implementation:
oImplement a recursive algorithm to predict future values based on past growth rates.
4.Analysis:
oDiscuss the time complexity of your recursive algorithm.
Explain how to optimize the recursive solution to avoid excessive computation. */

/* 1. Recursion is a function call itself to solve smaller subproblem until it reaches a base case 
 * eg for fibinacci normal recursion goes to 2^n whereas if we use dynamic programming where we dont repeat 
 * solving same problem we get two types Tabulation (Bottom Up) and Memorization(Top Down).For fibonacci
 * it gives O(n).Tabulation is better of space saving since memorization needs memo table and recursive stack.
 */

/*2. Mathematical expressions:
 * CI= p(1+r)^n
   SI=prt
   Effective rate of interest=(1+r/n)^n-1 p=principle amt,r=rate,n=time in yrs or months.
   SETUP:
   principle=currval
   nominal rate=nominal 
   A growth rate =rate
   number of years =years
 */

/*4. space complexcity is O(n) for all
 *   time complexcity:
 *   Recursion O(2^n)
 *   Memorization O(n)
 *   Tabulation O(n)
 */
import java.util.*;

public class FinancialForecast {
    public static double recursion(double currval, double rate, int years) {
        if (years == 0)
            return currval;
        return recursion(currval, rate, years - 1) * (1 + rate);
    }

    public static double memorization(double currval, double rate, int years, Map<Integer, Double> memo) {
        if (years == 0)
            return currval;
        if (memo.containsKey(years))
            return memo.get(years);
        double result = memorization(currval, rate, years - 1, memo) * (1 + rate);
        memo.put(years, result);
        return result;
    }

    public static double tabulation(double currval, double rate, int years) {
        double[] dp = new double[years + 1];
        dp[0] = currval;
        for (int i = 1; i <= years; i++) {
            dp[i] = dp[i - 1] * (1 + rate);
        }
        return dp[years];
    }

    public static double simpleInterest(double currval, double rate, int years) {
        return currval + (currval * rate * years);
    }

    public static double effectiveFromNominal(double nominal, int compPerYear) {
        return Math.pow(1 + nominal / compPerYear, compPerYear) - 1;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter principle value: ");
        double initial = sc.nextDouble();

        System.out.print("Enter number of years: ");
        int years = sc.nextInt();

        System.out.print("Do you have Nominal or Effective rate? (Enter N or E): ");
        String type = sc.next();

        double rate = 0.0;

        if (type.equalsIgnoreCase("N")) {
            System.out.print("Enter Nominal annual rate (e.g., 0.06 for 6%): ");
            double nominal = sc.nextDouble();
            System.out.print("Enter compounding periods per year (e.g., 12): ");
            int n = sc.nextInt();
            rate = effectiveFromNominal(nominal, n);
            System.out.printf("Calculated Effective Annual Rate: %.5f%n", rate);
        } else if (type.equalsIgnoreCase("E")) {
            System.out.print("Enter Effective annual rate (e.g., 0.0617): ");
            rate = sc.nextDouble();
        } else {
            System.out.println("Invalid input for rate type.");
            sc.close();
            return;
        }

        double resultRecursive = recursion(initial, rate, years);
        System.out.println("Future value (Recursion): " + resultRecursive);

        Map<Integer, Double> memo = new HashMap<>();
        double resultMemo = memorization(initial, rate, years, memo);
        System.out.println("Future value (Memoization): " + resultMemo);

        double resultTabulation = tabulation(initial, rate, years);
        System.out.println("Future value (Tabulation): " + resultTabulation);

        System.out.println("Simple Interest: " + simpleInterest(initial, rate, years));

        sc.close();
    }
}
