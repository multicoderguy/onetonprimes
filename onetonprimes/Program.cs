using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


class Program
{
    static void Main(string[] args)
    {
        int lowValue, highValue;
        // If user does pass in proper amount of args, show them usage
        if (args.Length != 2)
        {
            Console.WriteLine("usage: onetonprimes lowValue highValue");
            return;
        }
        try
        {
            // Cast arguments to int32
            lowValue = Convert.ToInt32(args[0]);
            highValue = Convert.ToInt32(args[1]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An incorrect parameter value was passed to the program: " + ex.Message);
            return;
        }

        int numOfPrimes = numberOfPrimes(lowValue, highValue);
        Console.WriteLine("Number of Primes between {0} and {1} is {2}",args[0], args[1], numOfPrimes.ToString());
    }

    private static int numberOfPrimes(int lowValue, int maxValue)
    {
        // if maxValue < 2 then we have no primes
        if (maxValue < 2) return 0;
        // create an array the size of max value
        BitArray primeCandidates = new BitArray(maxValue, true);
        // eliminate all values non-prime
        primeCandidates[0] = false;
        primeCandidates[1] = false;
        // sieve of eratosthenes to get all values between low and high
        for (int x = 0; (x*x) < maxValue; x++)
        {
            if (primeCandidates[x])
            {
                for (int y = (x*x); y < maxValue; y += x)
                {
                    primeCandidates[y] = false;
                }
            }
        }
        // small adjustment to array to eliminate all primes below lowValue
        for (int x = 0; x < lowValue; x++) primeCandidates[x] = false;
        // linq for quick count of remaining true values (primes)
        int numPrime = (from bool prime in primeCandidates where prime select prime).Count();
        return numPrime;
    }
}
