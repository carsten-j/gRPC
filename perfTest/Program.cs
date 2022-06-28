using BenchmarkDotNet.Running;
using perfTest;

var summary = BenchmarkRunner.Run<PerfRun>();
