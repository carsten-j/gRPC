# Tech talk - introduction to gRPC

But let us start talking a bit about HTTP. Today the most predominant style of creating API’s is HTTP Web API. The HTTP protocol is text based and most services use JSON. Those old enough might remember SOAP services using XML.

Let us say that I have a web server exposing some HTTP API that you want to call. And let us assume that the call succeeds with a 200 OK. 

What is the first thing you then as a developer want to do with the result?

Deserialise it to a “object” in your programming language.

Now you don’t need to deserialise all the data. In principal you can select the data you care about. And as long as you are tolerant reader you will survive if I add additional content to the response.

In that sense HTTP API with JSON are looser coupled.

gRPC on the other hand requires a common contract defining the operations as well as the data structure that are going to be exchanged through the operations.

gRPC required HTTP/2.

I am by now means expert in HTTP version but one advantage about HTTP/2 is that the format can be binary. gPRC uses this to generate smaller payloads and that enhances performance of gRPC over HTTP based API’s.

Let us look at an example of a contract.

The files containing contracts have extension .proto

protoc compiler generates data structures and stub implementation of the services

Many languages are supported: C++, C#, Java, Kotlin, PHP, Python, Dart, Go, Ruby, Objective-C

VS build action

Blazor WASM standard app in VS with an ASP.NET Core backend with HTTP API and a weather service

Here is the service implementation of the gRPC service defined in the proto file.

As with HTTP API controllers we need to setup a bit of plumbing in the startup.cs file

We talking about gRPC having smaller payloads and being faster than HTTP API based on JSON. So what is the catch here?

I mentioned that gRPC requires HTTP/2 and while it have been around since 2015 most browsers do NOT support HTTP/2 - adaption is slow!!!

So how do I show you that we actually can call our gRPC service hosted in ASP.NET Core.

We cannot use POSTMAN

I am a command line guy and luckily there is a tool called gRPCcurl. 

Do you all know cURL?

Command line tool for getting and transferring data - it has been around since mid 90’ties
Look at SWAGGER for the same cURL command




 