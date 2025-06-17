/*Exercise 1: Implementing the Singleton Pattern
Scenario: 
You need to ensure that a logging utility class in your application has only one instance throughout the application lifecycle to ensure consistent logging.
Steps:
1.Create a New Java Project:
oCreate a new Java project named SingletonPatternExample.
2.Define a Singleton Class:
oCreate a class named Logger that has a private static instance of itself.
oEnsure the constructor of Logger is private.
oProvide a public static method to get the instance of the Logger class.
3.Implement the Singleton Pattern:
oWrite code to ensure that the Logger class follows the Singleton design pattern.
4.Test the Singleton Implementation:
oCreate a test class to verify that only one instance of Logger is created and used across the application. */
public class Logger {
    private static Logger instance;

    private Logger() {
        System.out.print("initialized");
    }

    public static Logger getInstance() {
        if (instance == null) {
            instance = new Logger();
        }
        return instance;
    }

    public void log(String msg) {
        System.out.println("Log: " + msg);
    }
}
