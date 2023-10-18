using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace HandsOn.Labs.JsonSerializer;

[MemoryDiagnoser(true)]
public class PerformanceTestJsonSerialize
{
    private ComplexData? complexData;

    [GlobalSetup]
    public void Setup()
    {
        complexData = new ComplexData
        {
            Id = 1,
            Name = "Alejandro",
            Age = 30,
            IsStudent = true,
            Interests = new[] { "Programming", "Reading" },
            Address = new Address
            {
                City = "Gye",
                Street = "9 de Octubre",
                ZipCode = "090302"
            }
        };
    }

    [Benchmark]
    public string NewtonSoftJsonSerialize() =>
        JsonConvert.SerializeObject(complexData);

    [Benchmark]
    public string SystemTextJsonSerialize() =>
        System.Text.Json.JsonSerializer.Serialize(complexData);
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}

public class ComplexData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsStudent { get; set; }

    public Address Address { get; set; }

    public string[] Interests { get; set; }
}