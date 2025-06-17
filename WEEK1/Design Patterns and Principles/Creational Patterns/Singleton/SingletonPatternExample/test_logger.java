public class test_logger {
    public static void main(String[] args) {
        Logger l1 = Logger.getInstance();
        l1.log("Hi my name is Dipanwita");
        Logger l2 = Logger.getInstance();
        l2.log("I am in 4th year btech CSE");
        if (l1 == l2) {
            System.out.println("Both l1 and l2 are the same instance.");
        } else {
            System.out.println("Singleton failed.");
        }
    }
}
