using BenchmarkDotNet.Running;

namespace JsonBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ToJsonUtf8Comparision>();
            var summary1 = BenchmarkRunner.Run<FromJsonUtf8Comparision>();
        }
    }
}
