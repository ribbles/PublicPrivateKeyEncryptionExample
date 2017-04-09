using System;
using System.Linq;
using System.Numerics;

namespace PublicPrivateKeyEncryption
{
    class Program
    {
        static void Main()
        {
            int p = 17; // 1st large prime (larger)
            int q = 13; // 2nd large prime
            int pubKey1 = p*q;
            int pubKey2 = 11;// < pubKey1 - 65537 is commonly used
            int privKey = CalculateExtendedEuclideanAlgorithm(pubKey2, (p - 1) * (q - 1));

            Console.WriteLine("input\tcipher\tplain");
            foreach(char input in "this is the text")
            {
                var cipherText = BigInteger.Pow(input, pubKey2) % pubKey1;
                var plainText = (char)(BigInteger.Pow(cipherText, privKey) % pubKey1);

                Console.WriteLine($"{input}\t{cipherText}\t{plainText}");
                if (input != plainText) throw new ApplicationException($"{input} != {plainText}");
            }

            Console.ReadLine();
        }
        
        /// <summary>
        /// From http://amir-shenodua.blogspot.com/2012/06/extended-gcd-algorithm-extended.html
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int CalculateExtendedEuclideanAlgorithm(int a, int b)
        {
            if (a < b) //if A less than B, switch them
            {
                int temp = a;
                a = b;
                b = temp;
            }
            int r = b, q = 0;
            int x0 = 1, y0 = 0;
            int x1 = 0, y1 = 1;
            int x = 0, y = 0;
            while (r > 1)
            {
                r = a % b;
                q = a / b;
                x = x0 - q * x1;
                y = y0 - q * y1;
                x0 = x1;
                y0 = y1;
                x1 = x;
                y1 = y;
                a = b;
                b = r;
            }
            return new[] { r, x, y }.Where(z => z > 1).Min();
        }
    }
}
