using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberList
{
    public static class SequenceGenerator
    {
        /// <summary>
        /// Returns an array containing every integer from <paramref name="min"/> to
        /// <paramref name="max"/> (inclusive) in a uniformly random order.
        /// </summary>
        /// <param name="min">Inclusive lower bound of the range.</param>
        /// <param name="max">Inclusive upper bound of the range.</param>
        /// <returns>A shuffled array of length <c>max - min + 1</c>.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="min"/> is greater than <paramref name="max"/>.
        /// </exception>
        public static int[] Generate(int min, int max)
        {
            if (min > max)
                throw new ArgumentException(
                    $"min ({min}) must be less than or equal to max ({max}).");

            int count = max - min + 1;
            int[] sequence = BuildSequence(min, count);
            Shuffle(sequence);
            return sequence;
        }

        /// <summary>
        /// Allocates and fills the identity sequence [min, min+1, ..., min+count-1].
        /// </summary>
        private static int[] BuildSequence(int min, int count)
        {
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
                arr[i] = min + i;
            return arr;
        }

        /// <summary>
        /// In-place Fisher-Yates (Knuth) shuffle.
        /// Iterates from the last index down to 1; at each step picks a random
        /// index j in [0..i] and swaps arr[i] with arr[j].
        /// </summary>
        private static void Shuffle(int[] arr)
        {
            Random rng = Random.Shared;

            for (int i = arr.Length - 1; i > 0; i--)
            {
                // Random.Next(n) returns a value in [0, n), so the upper bound
                // must be i+1 to include index i itself in the candidate range.
                int j = rng.Next(i + 1);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }
}
