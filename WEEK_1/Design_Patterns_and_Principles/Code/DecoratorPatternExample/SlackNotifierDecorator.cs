public class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(Notifier notifier) : base(notifier) { }

    public override string Send()
    {
        return base.Send() + "\nSlack: Sent Slack notification.";
    }
}