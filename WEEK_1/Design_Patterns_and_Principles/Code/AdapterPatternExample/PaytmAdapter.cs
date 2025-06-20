public class PaytmAdapter : IPaymentProcessor
{
    private readonly Paytm _paytm;

    public PaytmAdapter(Paytm paytm)
    {
        _paytm = paytm;
    }

    public void ProcessPayment(string amount)
    {
        _paytm.PaytmTransaction(amount);
    }
}
