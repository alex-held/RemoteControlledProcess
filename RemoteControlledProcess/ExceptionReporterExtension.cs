using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Logging;

namespace RemoteControlledProcess
{
    public static class ExceptionReporterExtension
    {
        public static void Write(this Exception exception, TextWriter writer)
        {
            try
            {
                var stackFrame = new StackTrace(true).GetFrame(1);
                var fileName = stackFrame?.GetFileName();
                var lineNumber = stackFrame?.GetFileLineNumber();

                writer.WriteLine($"Unhandled exception in {fileName}:{lineNumber}");
                writer.WriteLine(exception.ToString());
            }
            catch
            {
                // ignore, since this logging failed and we do not want to crash the test-host 
            }
     
        }

        public static void Log(this Exception exception, ILogger logger)
        {
            try
            {
                var stackFrame = new StackTrace(true).GetFrame(1);
                var fileName = stackFrame?.GetFileName();
                var lineNumber = stackFrame?.GetFileLineNumber();

                logger.LogCritical(exception, "Unhandled exception in {FileName}:{@LineNumber}", fileName, lineNumber);
            }
            catch
            {
                // ignore, since this logging failed and we do not want to crash the test-host 
            }
        }
    }
}