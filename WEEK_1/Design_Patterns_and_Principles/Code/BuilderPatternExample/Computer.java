/*Exercise 3: Implementing the Builder Pattern
Scenario: 
You are developing a system to create complex objects such as a Computer with multiple optional parts. Use the Builder Pattern to manage the construction process.
Steps:
1.Create a New Java Project:
oCreate a new Java project named BuilderPatternExample.
2.Define a Product Class:
oCreate a class Computer with attributes like CPU, RAM, Storage, etc.
3.Implement the Builder Class:
oCreate a static nested Builder class inside Computer with methods to set each attribute.
oProvide a build() method in the Builder class that returns an instance of Computer.
4.Implement the Builder Pattern:
oEnsure that the Computer class has a private constructor that takes the Builder as a parameter.
5.Test the Builder Implementation:
oCreate a test class to demonstrate the creation of different configurations of Computer using the Builder pattern. */
public class Computer {
    private String CPU, RAM, Storage, Graphics;

    private Computer(Builder b) {
        this.CPU = b.CPU;
        this.RAM = b.RAM;
        this.Storage = b.Storage;
        this.Graphics = b.Graphics;
    }

    public void display() {
        System.out.println("CPU: " + CPU);
        System.out.println("RAM: " + RAM);
        System.out.println("Storage: " + Storage);
        System.out.println("Graphics Card: " + Graphics);
    }

    public static class Builder {
        private String CPU;
        private String RAM;
        private String Storage;
        private String Graphics;

        public Builder setCPU(String CPU) {
            this.CPU = CPU;
            return this;
        }

        public Builder setRAM(String RAM) {
            this.RAM = RAM;
            return this;
        }

        public Builder setStorage(String Storage) {
            this.Storage = Storage;
            return this;
        }

        public Builder setGraphicsCard(String Graphics) {
            this.Graphics = Graphics;
            return this;
        }

        public Computer build() {
            return new Computer(this);
        }
    }
}