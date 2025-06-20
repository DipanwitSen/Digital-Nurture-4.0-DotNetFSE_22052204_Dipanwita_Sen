/*Exercise 5: Implementing the Decorator Pattern
Scenario: 
You are developing a notification system where notifications can be sent via multiple channels (e.g., Email, SMS). Use the Decorator Pattern to add functionalities dynamically.
Steps:
1.Create a New Java Project:
oCreate a new Java project named DecoratorPatternExample.
2.Define Component Interface:
oCreate an interface Notifier with a method send().
3.Implement Concrete Component:
oCreate a class EmailNotifier that implements Notifier.
4.Implement Decorator Classes:
oCreate abstract decorator class NotifierDecorator that implements Notifier and holds a reference to a Notifier object.
oCreate concrete decorator classes like SMSNotifierDecorator, SlackNotifierDecorator that extend NotifierDecorator.
5.Test the Decorator Implementation:
oCreate a test class to demonstrate sending notifications via multiple channels using decorators.
*/
public interface Notifier
{
    string Send();
}
