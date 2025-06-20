using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Payment Processing System ===");

        Console.Write("Enter the amount (e.g., 500 INR): ");
        string? amount = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(amount))
        {
            Console.WriteLine("Amount cannot be empty.");
            return;
        }

        Console.WriteLine("Choose a payment gateway: PayPal / Razorpay / Paytm");
        string? choice = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(choice))
        {
            Console.WriteLine("Payment gateway not selected.");
            return;
        }

        choice = choice.Trim().ToLower();

        IPaymentProcessor? processor = null;

        switch (choice)
        {
            case "paypal":
                processor = new PaypalAdapter(new PaypalGateway());
                break;
            case "razorpay":
                processor = new RazorpayAdapter(new RazorpayGateway());
                break;
            case "paytm":
                processor = new PaytmAdapter(new Paytm());
                break;
            default:
                Console.WriteLine("Invalid payment gateway selected.");
                return;
        }

        processor.ProcessPayment(amount);
    }
}
