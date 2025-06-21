public class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(Notifier notifier) : base(notifier) { }

    public override string Send()
    {
        return base.Send() + "\nSMS: Sent SMS notification.";
    }
}