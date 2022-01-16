using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace TraceLib
{
    public class TraceHandler
    {
        //add a file receiver to which you want to write before using the write function
        public static async void AddReceiver(string filepath)
        {
            await Task.Run(() => {
                try
                {
                    FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate | FileMode.Append);
                    TextWriterTraceListener textWriterTraceListener = new TextWriterTraceListener(fileStream);
                    Trace.Listeners.Add(textWriterTraceListener);
                    Trace.AutoFlush = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to initialise Tracing.\n" +
                        "Exception message: " + ex.Message + '\n' +
                        "Exception stack trace: " + ex.StackTrace + '\n');
                }
            });
        }
        public static async void WriteLineAsync(string message)
        {
            await Task.Run(() =>
            {
                Trace.WriteLine(DateTime.Now + ": " + message);
            });
        }
    }
}
