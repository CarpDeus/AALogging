using Serilog.Core;
using Serilog;
using System;
using System.IO;
#if NET8_0_OR_GREATER
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Configuration.Json;
#endif

namespace AaTools
{
    /// <summary>
    /// Azure-Architect.com Logging class
    /// </summary>
    public abstract class AaLogging
    {

        /// <summary>
        /// Returns the constructor method for logging calls
        /// </summary>
        protected AaLogging() { }

        /// <summary>
        /// Log Exception object 
        /// </summary>
        /// <param name="exceptionError">Exception object to log</param>
        public static void Error(Exception exceptionError)
        {
            AaSerilog.GetInstance().Error(exceptionError, "Error Message");
        }

        /// <summary>
        /// Log a string error message
        /// </summary>
        /// <param name="ErrorMessage">String error message to log</param>
        public static void Error(string ErrorMessage)
        {
            AaSerilog.GetInstance().Error(ErrorMessage);
        }

        /// <summary>
        /// Log an information message
        /// </summary>
        /// <param name="logMessage">String message to log</param>
        public static void Info(string logMessage)
        {
            AaSerilog.GetInstance().Information(logMessage);
        }

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="logMessage">String message to log</param>
        public static void Warn(string logMessage)
        {
            AaSerilog.GetInstance().Warning(logMessage);
        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="logMessage">String message to log</param>
        public static void Debug(string logMessage)
        {
            AaSerilog.GetInstance().Debug(logMessage);
        }
    }

    /// <summary>
    /// Exposing the Serilog Logger for full access
    /// </summary>
    public static class AaSerilog
    {
        /// <summary>
        /// Get the instance of the logger
        /// </summary>
        /// <returns></returns>
        public static Logger GetInstance()
        {
#if NET8_0_OR_GREATER

            var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
#else
            return new LoggerConfiguration()
                             .ReadFrom.AppSettings()
                             //  All my settings here
                             .CreateLogger();
#endif
        }
    }
}