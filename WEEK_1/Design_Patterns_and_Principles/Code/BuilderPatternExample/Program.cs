using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Build Custom Computer");

        Console.Write("Enter CPU: ");
        string cpu = Console.ReadLine() ?? "";

        Console.Write("Enter RAM: ");
        string ram = Console.ReadLine() ?? "";

        Console.Write("Enter Storage: ");
        string storage = Console.ReadLine() ?? "";

        Console.Write("Enter Graphics Card (or press Enter to skip): ");
        string graphics = Console.ReadLine() ?? "";

        // Build the computer with user input
        var builder = new Computer.Builder()
                        .SetCPU(cpu)
                        .SetRAM(ram)
                        .SetStorage(storage);

        if (!string.IsNullOrWhiteSpace(graphics))
            builder.SetGraphicsCard(graphics);

        Computer customPC = builder.Build();

        Console.WriteLine("\n Custom Computer Configuration:");
        customPC.Display();
    }
}
