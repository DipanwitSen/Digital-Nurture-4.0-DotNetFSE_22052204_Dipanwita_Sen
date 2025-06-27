// ==============================
// 1. How Mocking Enhances TDD
// ==============================

/*
Test-Driven Development (TDD) is a software development practice where tests are written 
before the actual implementation. This leads to better-designed, bug-free code.

Mocking supports TDD by:
- Allowing early testing of logic without real dependencies (like DB or file system).
- Enabling isolation of the unit being tested.
- Making test cases faster and repeatable.
*/

// ==============================
// 2. What is Mocking in Unit Testing
// ==============================

/*
Mocking is the practice of replacing real implementations (like APIs, databases, files)
with fake objects during testing.

Why use mocking:
- To avoid actual network/database/file operations.
- To test behavior under different conditions (e.g., failures).
- To verify that certain methods were called (behavior verification).
*/

// ==============================
// 3. Types of Test Doubles
// ==============================

/*
- Stub: Returns pre-configured data. Does not track method calls.
- Mock: Returns data and also tracks/verifies method calls and interactions.
- Fake: Has a working implementation but not suitable for production (e.g., in-memory DB).
*/

// ==============================
// 4. Advantages of TDD
// ==============================

/*
- Early bug detection
- Improved design through small, testable units
- Better documentation via test cases
- Easier maintenance and less regression
*/

// ==============================
// 5. Dependency Injection (DI) and Its Importance in Testing
// ==============================

/*
Dependency Injection is a design pattern where dependencies (e.g., services, data sources)
are provided from outside the class instead of being created inside.

Types of DI:
- Constructor Injection: Injected through class constructor
- Method Injection: Injected as method parameters
- Property Injection: Injected via public properties

Benefits in testing:
- Allows easy substitution with mocks/fakes
- Makes code loosely coupled and highly testable
*/

// ==============================
// 6. Writing Testable Code with Moq
// ==============================

/*
Use Moq to create mock objects of interfaces.
You can configure expected return values, and verify that certain methods were called.

Example:
var mock = new Mock<IService>();
mock.Setup(x => x.GetData()).Returns("Test");

var service = new MyClass(mock.Object);
Assert.AreEqual("Test", service.GetData());
*/

// ==============================
// 7. Mocking Database for Unit Testing
// ==============================

/*
Accessing real databases in unit tests is slow and unreliable.
Instead, create a mock of the data access layer or repository interface.

Example:
var mockRepo = new Mock<ICustomerRepository>();
mockRepo.Setup(x => x.GetCustomerById(1)).Returns(new Customer { Id = 1, Name = "John" });

This isolates your test from DB logic and keeps tests fast.
*/

// ==============================
// 8. Mocking File System for Unit Testing
// ==============================

/*
Reading or writing to actual files during tests can cause side effects.
Instead, create an IFileReader interface and mock its behavior.

Example:
var mockFileReader = new Mock<IFileReader>();
mockFileReader.Setup(f => f.ReadFile("input.txt")).Returns("Test data");

This keeps tests safe, fast, and independent of file system state.
*/

// ==============================
// Summary: When and Why to Use Mocks
// ==============================

/*
Use mocks when:
- The dependency is external (DB, FileSystem, Web API)
- You want to simulate success/failure behavior
- You want to verify method call counts or arguments
- You want fast and independent unit tests
*/

using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests
{
    [TestFixture]
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailSent()
        {
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);
            bool result = customerComm.SendMailToCustomer();
            Assert.IsTrue(result);
            mockMailSender.Verify(m => m.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}
