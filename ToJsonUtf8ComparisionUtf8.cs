using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using Jsonics;
using Newtonsoft.Json;
using System;
using System.Text;
using SpanJsonNamespace = SpanJson;

namespace JsonBenchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ToJsonUtf8Comparision
    {
        JsonTestClass _jsonTestClass;
        IJsonConverter<JsonTestClass> _jsonConverter;

        JsonSrcGen.JsonConverter _jsonSrcGenConverter = new JsonSrcGen.JsonConverter();

        public ToJsonUtf8Comparision()
        {
            _jsonTestClass = new JsonTestClass()
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 21,
                Registered = true
            };
            _jsonConverter = JsonFactory.Compile<JsonTestClass>();
        }


        [Benchmark]
        public ReadOnlySpan<byte> JsonSrcGenUtf8() => _jsonSrcGenConverter.ToJsonUtf8(_jsonTestClass);

        [Benchmark]
        public byte[] UTF8Json() => Utf8Json.JsonSerializer.Serialize(_jsonTestClass);

        [Benchmark]
        public byte[] Newtonsoft()
        {
            string json = JsonConvert.SerializeObject(_jsonTestClass);
            return Encoding.UTF8.GetBytes(json);
        }

        [Benchmark]
        public byte[] NetJson()
        {
            string json = NetJSON.NetJSON.Serialize(_jsonTestClass);
            return Encoding.UTF8.GetBytes(json);
        }

        [Benchmark]
        public byte[] JIL()
        {
            string json = Jil.JSON.Serialize(_jsonTestClass);
            return Encoding.UTF8.GetBytes(json);
        }

        [Benchmark]
        public byte[] SpanJson() => SpanJsonNamespace.JsonSerializer.Generic.Utf8.Serialize(_jsonTestClass);

        [Benchmark]
        public byte[] SystemTextJson()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes<JsonTestClass>(_jsonTestClass);
        }
    }
}