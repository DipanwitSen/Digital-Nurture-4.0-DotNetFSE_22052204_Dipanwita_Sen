using System;

class Program
{
    static void Main(string[] args)
    {
        Notifier baseNotifier = new EmailNotifier("System maintenance");

        Notifier smsNotifier = new SMSNotifierDecorator(baseNotifier);
        Notifier slackNotifier = new SlackNotifierDecorator(smsNotifier);

        Console.WriteLine(slackNotifier.Send());
    }
}
