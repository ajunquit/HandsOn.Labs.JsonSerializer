# Hands-on Labs: JsonSerializer
In this Hands-on Lab, we are going to focus on optimization between 'Newtonsoft.Json.JsonConvert.SerializeObject()' and 'System.Text.Json.JsonSerializer.Serialize()' using BenchmarkDotNet. We will also learn how to effectively do that using the MemoryDiagnoser attribute while comparing a couple way to serialize an object.

## The Prerequisites
You are able to install the package via Package Manager Console or .NET cli. In this Lab, we are going to use the Package Manager Console.

1. Open your project in Visual Studio.

2. Go to the "Tools" menu and select "NuGet Package Manager" and then "Package Manager Console."

3. In the Package Manager Console, you can use the `Install-Package` command to install the required packages. First, install `BenchmarkDotNet` with the following command:

```powershell
Install-Package BenchmarkDotNet
```

4. Next, install `Newtonsoft.Json` with this command:

```powershell
Install-Package Newtonsoft.Json
```

After running these commands, the necessary packages will be installed in your project, and you can proceed to build and run the code with the provided package references.

## The Code
So, let’s set with the code:
```csharp
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
```
This C# code is used to perform performance tests on JSON object serialization using two different libraries: Newtonsoft.Json and System.Text.Json. JSON object serialization involves converting an object into a JSON string that can be used for data exchange or storage.

Here is a description of what is happening in the code:

1. `[MemoryDiagnoser(true)]`: This attribute is applied to the `PerformanceTestJsonSerialize` class. It enables memory profiling for the benchmarks, which means that in addition to measuring execution time, the code will also gather information about memory usage during benchmark runs.

2. `PerformanceTestJsonSerialize` class: This class contains methods for benchmarking the performance of JSON serialization using two different libraries: Newtonsoft.Json and System.Text.Json.

3. `private ComplexData? complexData;`: A private field `complexData` of type `ComplexData?` is declared. This variable will be used to hold a sample data object of the `ComplexData` type for serialization.

4. `[GlobalSetup]` method: The `Setup()` method is decorated with the `[GlobalSetup]` attribute, indicating that it will run once before any benchmarks are executed. This method initializes the `complexData` object with sample data.

5. Sample Data Initialization: Inside the `Setup()` method, the `complexData` object is initialized with a sample data structure. This data structure includes an ID, name, age, student status, interests, and an address.

6. `[Benchmark]` methods:
   - `NewtonSoftJsonSerialize()`: This method is decorated with the `[Benchmark]` attribute. It uses the Newtonsoft.Json library (`JsonConvert.SerializeObject`) to serialize the `complexData` object into a JSON string. The method returns the resulting JSON string.
   - `SystemTextJsonSerialize()`: This method is also decorated with the `[Benchmark]` attribute. It uses the System.Text.Json library (`System.Text.Json.JsonSerializer.Serialize`) to perform the same JSON serialization process and return the JSON string.

With the `[MemoryDiagnoser(true)]` attribute, the code will collect memory-related performance data, allowing you to assess the memory efficiency of the JSON serialization operations alongside the execution time performance. This can be valuable for optimizing memory usage in your application. The benchmarks will measure how well each JSON serialization library performs in terms of both time and memory consumption.


## The Summary
In summary, this code defines a performance test class that compares the performance of the Newtonsoft.Json and System.Text.Json libraries when serializing a `ComplexData` object to JSON format. Special attributes are used to set up data initialization and measure the performance of serialization.

In the next picture, we could conclude "System.Text.Json" is more efficient that Newtonsoft. 
- Mean: Arithmetic mean of all measurements
- Error: Half of 99.9% confidence interval
- StdDev: Standard deviation of all measurements
- Gen0: Garbage collections per 1000 operations.
- Allocated: It displays the allocated memory per single operation in bytes.

![image](https://github.com/ajunquit/HandsOn.Labs.JsonSerializer/assets/26319954/50a4c425-2de3-4a44-971b-57a3caccd827)
