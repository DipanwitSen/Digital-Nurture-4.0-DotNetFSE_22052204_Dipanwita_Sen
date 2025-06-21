public abstract class NotifierDecorator : Notifier
{
    protected Notifier wrappee;

    public NotifierDecorator(Notifier wrappee)
    {
        this.wrappee = wrappee;
    }

    public virtual string Send()
    {
        return wrappee.Send();
    }
}
