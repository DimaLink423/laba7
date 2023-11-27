using System;

class MillerRabinTest
{
    static int Power(int a, int d, int n)
    {
        int result = 1;
        a %= n;

        while (d > 0)
        {
            if ((d & 1) == 1)
                result = (result * a) % n;

            d >>= 1;
            a = (a * a) % n;
        }

        return result;
    }

    static bool MillerRabinTestPrime(int n, int k)
    {
        if (n <= 1 || n == 4)
            return false;
        if (n <= 3)
            return true;

        int d = n - 1;
        while (d % 2 == 0)
            d /= 2;

        Random rand = new Random();

        for (int i = 0; i < k; i++)
        {
            int a = rand.Next(2, n - 2);
            int x = Power(a, d, n);

            if (x == 1 || x == n - 1)
                continue;

            bool isProbablePrime = false;
            while (d != n - 1)
            {
                x = (x * x) % n;
                d *= 2;

                if (x == 1)
                    return false;
                if (x == n - 1)
                {
                    isProbablePrime = true;
                    break;
                }
            }

            if (!isProbablePrime)
                return false;
        }

        return true;
    }

    static void Main()
    {
        int numberToCheck = 101; // введи число, яке хочеш перевірити на простоту
        int rounds = 5; // кількість раундів

        if (MillerRabinTestPrime(numberToCheck, rounds))
        {
            Console.WriteLine($"{numberToCheck} є простим числом.");

            double probability = 1 - Math.Pow(0.25, rounds);
            Console.WriteLine($"Ймовірність того, що воно просте: {probability:P}");
        }
        else
        {
            Console.WriteLine($"{numberToCheck} скоріш за все не є простим числом.");
        }
    }
}
