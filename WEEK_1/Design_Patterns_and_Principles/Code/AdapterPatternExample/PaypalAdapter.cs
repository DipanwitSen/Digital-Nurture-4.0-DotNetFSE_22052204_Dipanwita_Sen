public class PaypalAdapter : IPaymentProcessor
{
    private readonly PaypalGateway _paypal;
    /* creating readonly private instance*/

    public PaypalAdapter(PaypalGateway paypal)
    {
        _paypal = paypal;
    }

    public void ProcessPayment(string amount)
    {
        _paypal.MakePayPalPayment(amount);
    }
}
