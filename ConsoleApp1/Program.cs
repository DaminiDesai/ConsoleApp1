using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Lista enlazada con eliminación por rango");
            Console.WriteLine("2. Manejo de listas de números primos y Armstrong");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    EliminarPorRango();
                    break;
                case 2:
                    ManejarListasPrimosArmstrong();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    // Ejercicio 4: Lista enlazada con eliminación por rango
    static void EliminarPorRango()
    {
        LinkedList<int> numbers = new LinkedList<int>();
        Random random = new Random();

        for (int i = 0; i < 50; i++)
        {
            numbers.AddLast(random.Next(1, 1000));
        }

        Console.WriteLine("Números generados:");
        foreach (var number in numbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();

        Console.Write("Ingrese el límite inferior del rango: ");
        int lowerLimit = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el límite superior del rango: ");
        int upperLimit = int.Parse(Console.ReadLine());

        var current = numbers.First;
        while (current != null)
        {
            var next = current.Next;
            if (current.Value < lowerLimit || current.Value > upperLimit)
            {
                numbers.Remove(current);
            }
            current = next;
        }

        Console.WriteLine("\nNúmeros dentro del rango:");
        foreach (var number in numbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }

    // Ejercicio 5: Manejo de listas de números primos y Armstrong
    static void ManejarListasPrimosArmstrong()
    {
        LinkedList<int> primes = new LinkedList<int>();
        LinkedList<int> armstrongNumbers = new LinkedList<int>();

        Console.WriteLine("Ingrese números enteros (escriba '0' para terminar):");
        while (true)
        {
            int num = int.Parse(Console.ReadLine());
            if (num == 0) break;

            if (IsPrime(num))
            {
                primes.AddLast(num);
            }

            if (IsArmstrong(num))
            {
                armstrongNumbers.AddFirst(num);
            }
        }

        Console.WriteLine($"\nCantidad de números primos: {primes.Count}");
        Console.WriteLine($"Cantidad de números Armstrong: {armstrongNumbers.Count}");

        if (primes.Count > armstrongNumbers.Count)
        {
            Console.WriteLine("La lista de números primos tiene más elementos.");
        }
        else if (primes.Count < armstrongNumbers.Count)
        {
            Console.WriteLine("La lista de números Armstrong tiene más elementos.");
        }
        else
        {
            Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");
        }

        Console.WriteLine("\nNúmeros primos:");
        foreach (var prime in primes)
        {
            Console.Write($"{prime} ");
        }

        Console.WriteLine("\n\nNúmeros Armstrong:");
        foreach (var armstrong in armstrongNumbers)
        {
            Console.Write($"{armstrong} ");
        }
        Console.WriteLine();
    }

    // Método para verificar si un número es primo
    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

    // Método para verificar si un número es Armstrong
    static bool IsArmstrong(int num)
    {
        int original = num, sum = 0;
        int digits = num.ToString().Length;

        while (num > 0)
        {
            int digit = num % 10;
            sum += (int)Math.Pow(digit, digits);
            num /= 10;
        }

        return sum == original;
    }
}
