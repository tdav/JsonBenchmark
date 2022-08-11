using BenchmarkDotNet.Attributes;
using Jsonics;
using JsonSrcGen;
using System.Text;

namespace JsonBenchmark
{
    public class FromJsonComparision
    {
        byte[] _jsonBA;
        string _json;
        IJsonConverter<JsonTestClass> _jsonConverter;

        public FromJsonComparision()
        {
            _json = "{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"Age\":12,\"Registered\":true}";
            _jsonConverter = JsonFactory.Compile<JsonTestClass>();
        }

        [Benchmark]
        public JsonTestClass Jsonics() => _jsonConverter.FromJson(_json);




        [Benchmark]
        public JsonTestClass NewtonsoftJson() => Newtonsoft.Json.JsonConvert.DeserializeObject<JsonTestClass>(_json);

        [Benchmark]
        public JsonTestClass NetJson() => NetJSON.NetJSON.Deserialize<JsonTestClass>(_json);

        [Benchmark]
        public JsonTestClass JIL() => Jil.JSON.Deserialize<JsonTestClass>(_json);

        [Benchmark]
        public JsonTestClass UTF8JSon()
        {
            var jsonBytes = Encoding.UTF8.GetBytes(_json);
            return Utf8Json.JsonSerializer.Deserialize<JsonTestClass>(jsonBytes);
        }

        [Benchmark]
        public JsonTestClass SpanJSON()
        {
            return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<JsonTestClass>(_json);
        }

        [Benchmark]
        public JsonTestClass SystemTextJson()
        {
            return System.Text.Json.JsonSerializer.Deserialize<JsonTestClass>(_json);
        }

        JsonTestClass _jsonTextClass = new JsonTestClass();
        JsonConverter _jsonSrcGenConverter = new JsonConverter();

        [Benchmark]
        public JsonTestClass JsonSrcGen()
        {
            _jsonSrcGenConverter.FromJson(_jsonTextClass, _json);
            return _jsonTextClass;
        }
    }
}