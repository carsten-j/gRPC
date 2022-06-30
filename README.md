# Internal Tech talk - introduction to gRPC

Let us start off by talking a bit about HTTP. Today the most predominant style of creating API’s is 
HTTP Web API. The HTTP protocol is text based and most services use JSON. 
Those among the audience old enough might remember the good old days when SOAP services using XML
where predominant.

Let us say that I have a web server exposing some HTTP API that you want to call. 
And let us assume that the call succeeds with a 200 OK. 

What is the first thing you then as a developer want to do with the result?

> Deserialise it to a “object” in your programming language.

Now you don’t need to deserialise all the data. In principal you can select just the data that you care about. 
And as long as you are tolerant reader you will survive if I add additional content to the response.

In that sense HTTP API baded JSON can be considered loosely coupled.

gRPC on the other hand requires a common contract defining the operations as well as the data
structure that are going to be exchanged through the operations.

gRPC requires HTTP/2.

I am by now means expert in HTTP version but one advantage about HTTP/2 is that the format can
be binary. gPRC uses this to generate smaller payloads and that enhances performance of gRPC
over HTTP based API’s.

Let us look at an example of a contract (demo).

The files containing contracts have extension .proto

protoc compiler generates data structures and stub implementation of the services

Many languages are supported: C++, C#, Java, Kotlin, PHP, Python, Dart, Go, Ruby, Objective-C

In Visual Studio the build action for .proto files is set.

Blazor WASM standard app in VS with an ASP.NET Core backend with HTTP API and a weather service.
This is the standard Blazor app when creating a new project.

Here is the service implementation of the gRPC service defined in the proto file.
In .NET gRPC services can be hosted in an ASP.NET Core project.

As with HTTP API controllers we need to setup a bit of plumbing in the program.cs file

I mentioned that gRPC has smaller payloads and is faster than HTTP API based on JSON. 
So what is the catch here?

I mentioned that gRPC requires HTTP/2 and while it have been around since 2015 most browsers do 
__NOT__ support HTTP/2 - adaption is slow!!!

So how do I show you that we actually can call our gRPC service hosted in ASP.NET Core.

We cannot use POSTMAN (actually we can according to Thomas)

I am a command line guy and luckily there is a tool called gRPCcurl. 

Do you all know cURL?

Command line tool for getting and transferring data - it has been around since mid 90’ties
Look at SWAGGER for the an example of a cURL command

> c:/Tools/grpcurl.exe localhost:7069 describe

> c:/Tools/grpcurl.exe localhost:7069 describe WeatherForecast.WeatherRequest

> c:/Tools/grpcurl.exe -d '{}' localhost:7069 WeatherForecast.WeatherForecast/GetWeather

We can also write a C# client (demo).






 