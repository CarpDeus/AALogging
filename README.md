
# AaLogging
This is a nuget package being put out as a part of AaTools. This package handles logging. It is actually a wrapper for Serilog but it works with all of the existing code I have written that has used a nubmer of different logging backends.
Current release is 1.0. 
Documentation can be found [here](./AALoggingPackage/Documentation/V1/AaTools/index.md)

The package includes file and console sinks. The beauty of this package is that you can include any [Serilog.Sink](https://github.com/serilog/serilog/wiki/Provided-Sinks) in your project and, as long as you configure it, it will be used by this interface.

For configuring in .NET 4.8, use the App.config
```xml
	<appSettings>
		<add key="serilog:minimum-level" value="Verbose" />
		<add key="serilog:using:Console" value="Serilog.Sinks.Console" />
		<add key="serilog:write-to:Console" />
		<add key="serilog:using:File" value="Serilog.Sinks.File" />
		<add key="serilog:write-to:File.path" value=".\Logs\AaLoggingTest.txt" />
		<add key="serilog:write-to:File.retainedFileCountLimit" value="10" />
		<add key="serilog:write-to:File.rollingInterval" value="Minute" />
		<add key="serilog:write-to:File.shared" value="true" />
	</appSettings>
```
For .NET 8 use appsettings.json
```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File"],
    "MinimumLevel": "Debug",
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": ".\\Logs\\MbxBaseStandardTest.txt",
          "rollingInterval": "Hour",
          "shared": true
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithMachineName", "WithThreadId" ]
  }
}
```
