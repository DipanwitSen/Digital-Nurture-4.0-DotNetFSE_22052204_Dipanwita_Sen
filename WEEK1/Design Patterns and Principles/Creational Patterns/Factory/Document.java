/*Exercise 2: Implementing the Factory Method Pattern
Scenario: 
You are developing a document management system that needs to create different types of documents (e.g., Word, PDF, Excel). Use the Factory Method Pattern to achieve this.
Steps:
1.Create a New Java Project:
oCreate a new Java project named FactoryMethodPatternExample.
2.Define Document Classes:
oCreate interfaces or abstract classes for different document types such as WordDocument, PdfDocument, and ExcelDocument.
3.Create Concrete Document Classes:
oImplement concrete classes for each document type that implements or extends the above interfaces or abstract classes.
4.Implement the Factory Method:
oCreate an abstract class DocumentFactory with a method createDocument().
oCreate concrete factory classes for each document type that extends DocumentFactory and implements the createDocument() method.
5.Test the Factory Method Implementation:
oCreate a test class to demonstrate the creation of different document types using the factory method. */

public interface Document {
    void open();
}
