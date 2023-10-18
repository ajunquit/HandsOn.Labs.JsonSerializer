# Hands-on Labs: JsonSerializer
In this Hands-on Lab, we are going to focus on optimization between 'Newtonsoft.Json.JsonConvert.SerializeObject()' and 'System.Text.Json.JsonSerializer.Serialize()' using BenchmarkDotNet. We will also learn how to effectively do that using the MemoryDiagnoser attribute while comparing a couple way to serialize an object.

## Prerequisites
BenchmarkDotNet:
To execute the performance test, it's necessary to install 'BenchmarkDotNet'.
```
Install-Package BenchmarkDotnet
```
Newtonsoft:
Go to Package Manager Console and execute the next command:
```
Install-Package Newtonsoft.Json
```
## Summary

![image](https://github.com/ajunquit/HandsOn.Labs.JsonSerializer/assets/26319954/50a4c425-2de3-4a44-971b-57a3caccd827)
