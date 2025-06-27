/*
 * What is Unit Testing?
 * ----------------------
 * Unit testing involves testing the **smallest individual unit** of code — 
 * typically a method or function — in isolation from the rest of the system.
 * 
 * Unit tests are:
 * - Fast
 * - Focused on logic
 * - Can use mocking to isolate dependencies

 * What is Functional Testing?
 * ----------------------------
 * Functional testing validates the system as a whole against business requirements.
 * It checks if the system behaves correctly with real inputs.
 * 
 * Key Difference:
 * - Unit testing checks internal correctness of code units.
 * - Functional testing checks external behavior and user-facing features.

 * Unit testing often uses **mocking** for:
 * - Simulating databases, file systems, or APIs
 * - Isolating the method under test from external dependencies
 */

/*
 * Types of Testing:
 * ------------------
 * 1. Unit Testing:
 *    - Tests individual methods or classes in isolation.
 *    - Uses NUnit, xUnit, MSTest frameworks.

 * 2. Functional Testing:
 *    - Tests if the software behaves as expected.
 *    - Done using tools like Selenium, Postman.

 * 3. Automated Testing:
 *    - Tests are executed automatically using scripts/tools.
 *    - Faster and more reliable than manual testing.

 * 4. Performance Testing:
 *    - Measures system performance under load.
 *    - Checks response time, throughput, resource usage.
 */

/*
 * What is a Loosely Coupled & Testable Design?
 * ---------------------------------------------
 * - Loosely coupled design means components do not depend heavily on each other.
 * - It makes the code easier to test, maintain, and extend.
 *
 * Example of Tight Coupling (Bad):
 * public class ReportGenerator {
 *     private Database db = new Database(); // tightly coupled
 * }

 * Example of Loose Coupling (Good):
 * public class ReportGenerator {
 *     private readonly IDatabase db;
 *     public ReportGenerator(IDatabase db) {
 *         this.db = db;
 *     }
 * }
 * 
 * Here, we can pass a mock `IDatabase` while testing without touching the real DB.
 */

/*
 * Understanding [SetUp], [TearDown], and [Ignore]:
 * ------------------------------------------------
 * [SetUp]     → Runs before every test method. Used to initialize resources.
 * [TearDown]  → Runs after every test method. Used for cleanup (e.g., reset variables).
 * [Ignore]    → Temporarily skips a test. Useful when a test is incomplete or under review.
 */

/*
 * Benefits of Parameterized Test Cases:
 * --------------------------------------
 * - Reduce code duplication.
 * - Test multiple inputs and expected results using a single method.
 * - Easy to expand and maintain.
*/

/*
 * What is Mocking? (Using Moq Framework):
 * ---------------------------------------
 * - Mocking is the act of simulating the behavior of real objects in testing.
 * - Especially useful for dependencies like:
 *   - Databases
 *   - File systems
 *   - Web APIs
 * - It helps in isolating the code being tested.

 * Moq Example:
 * var mockRepo = new Mock<IUserRepository>();
 * mockRepo.Setup(repo => repo.GetUser("admin")).Returns(new User { Name = "admin" });

 * Benefits:
 * - Test in isolation without needing real DB/API
 * - Control return values for edge cases
 * - Improve speed and stability of tests
 */


/*
 * Why Testing Private Methods is Not Beneficial:
 * -------------------------------------------------
 * Unit testing should focus on the public interface of a class.
 * Private methods are implementation details — they may change 
 * frequently even if the public behavior stays the same.
 * 
 * Instead of testing private methods directly, test the public 
 * methods that use them. This ensures that your tests stay 
 * stable and focused on actual system behavior.
 */

using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibraryTests
{
    [TestFixture]
    public class CalculatorTests
    {
        SimpleCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator.AllClear();
        }

        [Test]
        public void Addition_WithTwoPositiveNumbers_ReturnsCorrectResult()
        {
            double result = calculator.Addition(10, 20);
            Assert.That(result, Is.EqualTo(30));
        }

        [TestCase(2, 3, 5)]
        [TestCase(-4, -6, -10)]
        [TestCase(10.5, 4.5, 15)]
        [TestCase(0, 0, 0)]
        public void Addition_ParameterizedTests(double a, double b, double expected)
        {
            double result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 5, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-3, -2, -1)]
        public void Subtraction_ParameterizedTests(double a, double b, double expected)
        {
            double result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 6)]
        [TestCase(-4, -5, 20)]
        [TestCase(3.5, 2, 7)]
        [TestCase(0, 10, 0)]
        public void Multiplication_ParameterizedTests(double a, double b, double expected)
        {
            double result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(7.5, 2.5, 3)]
        [TestCase(-8, -2, 4)]
        public void Division_ParameterizedTests(double a, double b, double expected)
        {
            double result = calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calculator.Division(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void AllClear_ShouldResetResult()
        {
            calculator.Addition(10, 20);
            calculator.AllClear();
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }

        [Test, Ignore("This test is temporarily disabled")]
        public void IgnoredTestExample()
        {
            Assert.Fail("This test is ignored");
        }
    }
}
