# JsonBenchmark
Project for compairing the performance of .net JSON libraries

## Usage
To run do:
###    dotnet run -c Release 


BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1826 (21H1/May2021Update)
Intel Core i5-10400F CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-preview.6.22352.1
  [Host]     : .NET 7.0.0 (7.0.22.32404), X64 RyuJIT
  DefaultJob : .NET 7.0.0 (7.0.22.32404), X64 RyuJIT
  
## ToJson  
  
|         Method |      Mean |    Error |   StdDev | Rank |  Gen 0 | Allocated |
|--------------- |----------:|---------:|---------:|-----:|-------:|----------:|
| JsonSrcGenUtf8 |  72.18 ns | 0.577 ns | 0.539 ns |    1 |      - |         - |
|       UTF8Json | 108.94 ns | 1.257 ns | 1.050 ns |    2 | 0.0153 |      96 B |
|       SpanJson | 115.55 ns | 0.295 ns | 0.261 ns |    3 | 0.0153 |      96 B |
|        NetJson | 184.39 ns | 0.695 ns | 0.616 ns |    4 | 0.0458 |     288 B |
|            JIL | 260.88 ns | 2.366 ns | 2.214 ns |    5 | 0.1426 |     896 B |
| SystemTextJson | 281.70 ns | 1.534 ns | 1.435 ns |    6 | 0.0391 |     248 B |
|     Newtonsoft | 681.95 ns | 3.137 ns | 2.935 ns |    7 | 0.2537 |   1,592 B |


## FromJson


|         Method |       Mean |    Error |  StdDev | Rank |  Gen 0 |  Gen 1 | Allocated |
|--------------- |-----------:|---------:|--------:|-----:|-------:|-------:|----------:|
|     JsonSrcGen |   109.9 ns |  0.53 ns | 0.45 ns |    1 | 0.0101 |      - |      64 B |
|       SpanJSON |   132.5 ns |  1.52 ns | 1.42 ns |    2 | 0.0165 |      - |     104 B |
|            JIL |   206.1 ns |  1.78 ns | 1.66 ns |    3 | 0.0572 |      - |     360 B |
|       UTF8JSon |   211.8 ns |  1.06 ns | 0.94 ns |    4 | 0.0165 |      - |     104 B |
|        NetJson |   345.6 ns |  2.09 ns | 1.85 ns |    5 | 0.0725 |      - |     456 B |
| SystemTextJson |   405.5 ns |  2.60 ns | 2.43 ns |    6 | 0.0162 |      - |     104 B |
| NewtonsoftJson | 1,217.6 ns | 10.42 ns | 9.75 ns |    7 | 0.4616 | 0.0019 |   2,896 B |
