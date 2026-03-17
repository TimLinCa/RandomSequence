using System.Diagnostics;

namespace RandomNumberList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            int[] numbers = SequenceGenerator.Generate(1, 10000);

            stopwatch.Stop();

            // Print first 20 and last 20 numbers as a preview
            PrintPreview(numbers, 20);

            Console.WriteLine($"Elapsed time : {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
        }

        private static void PrintPreview(int[] sequence, int previewCount)
        {
            int total = sequence.Length;
            Console.WriteLine($"--- First {previewCount} values ---");
            Console.WriteLine(string.Join(", ", sequence[..previewCount]));

            Console.WriteLine($"\n--- Last {previewCount} values ---");
            Console.WriteLine(string.Join(", ", sequence[(total - previewCount)..]));
        }
    }
}
