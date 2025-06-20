public class RazorpayAdapter : IPaymentProcessor
{
    private readonly RazorpayGateway _razorpay;

    public RazorpayAdapter(RazorpayGateway razorpay)
    {
        _razorpay = razorpay;
    }

    public void ProcessPayment(string amount)
    {
        _razorpay.ExecuteRazorTransaction(amount);
    }
}
