using BenchmarkDotNet.Running;

namespace DBBenchmark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var insertSummary = BenchmarkRunner.Run<DBInsertBenchmark>();
            var collectSummary = BenchmarkRunner.Run<DBGetCollectionBenchmark>();
            var updateSummary = BenchmarkRunner.Run<DBUpdateBenchmark>();
        }
    }
}