public class EmailNotifier : Notifier
{
    private string context;

    public EmailNotifier(string context)
    {
        this.context = context;
    }

    public string Send()
    {
        return context;
    }
}
