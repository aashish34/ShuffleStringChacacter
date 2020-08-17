using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RandomStringGenerator
{
    public interface IShuffleString
    {
        RandomStringResponse OneLinerSimpleSolution(string originalString);

        RandomStringResponse UsingRandomSolution(string originalString);

        RandomStringResponse ThreadSafeUsingFisherYatesSolution(string originalString);
    }
    public class ShuffleString: IShuffleString
    {
        public RandomStringResponse OneLinerSimpleSolution(string originalString)
        {
            return new RandomStringResponse
            {
                GeneratedRandomString = new string(originalString?.ToCharArray().OrderBy(x => new Random().Next()).ToArray()),
                Success = true
            };
        }

        public RandomStringResponse UsingRandomSolution(string originalString)
        {
            System.Random rnd = new System.Random();

            int index;
            List<char> chars = new List<char>(originalString);
            StringBuilder sb = new StringBuilder();
            while (chars.Count > 0)
            {
                index = rnd.Next(chars.Count);
                sb.Append(chars[index]);
                chars.RemoveAt(index);
            }

            return new RandomStringResponse
            {
                GeneratedRandomString = sb.ToString(),
                Success = true
            };
        }

        public RandomStringResponse ThreadSafeUsingFisherYatesSolution(string originalString)
        {
            int n = originalString.Length;
            var charArrays = originalString.ToCharArray();
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                char value = charArrays[k];
                charArrays[k] = charArrays[n];
                charArrays[n] = value;
            }

            return new RandomStringResponse
            {
                GeneratedRandomString = new string(charArrays),
                Success = true
            };
        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
}
