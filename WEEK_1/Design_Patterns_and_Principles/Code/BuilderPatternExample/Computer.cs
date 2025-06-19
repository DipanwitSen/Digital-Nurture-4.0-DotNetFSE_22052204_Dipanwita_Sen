using System;

public class Computer
{
    private string? CPU;
    private string? RAM;
    private string? Storage;
    private string? Graphics;

    private Computer(Builder builder)
    {
        this.CPU = builder.CPU;
        this.RAM = builder.RAM;
        this.Storage = builder.Storage;
        this.Graphics = builder.Graphics;
    }

    public void Display()
    {
        Console.WriteLine("CPU: " + CPU);
        Console.WriteLine("RAM: " + RAM);
        Console.WriteLine("Storage: " + Storage);
        Console.WriteLine("Graphics Card: " + Graphics);
    }

    public class Builder
    {
        public string? CPU;
        public string? RAM;
        public string? Storage;
        public string? Graphics;

        public Builder SetCPU(string cpu) { this.CPU = cpu; return this; }
        public Builder SetRAM(string ram) { this.RAM = ram; return this; }
        public Builder SetStorage(string storage) { this.Storage = storage; return this; }
        public Builder SetGraphicsCard(string graphics) { this.Graphics = graphics; return this; }

        public Computer Build() { return new Computer(this); }
    }
}
