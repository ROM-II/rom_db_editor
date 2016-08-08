using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runes.Net.Shared
{
    public sealed class  Logger : IDisposable
    {
        public bool OuptutTime { get; set; }
        public bool UseStubs { get; private set; }
        public bool FileIsOpen { get; private set; }
        private StreamWriter File { get; set; }

        public Logger(string fileName = "program.log", bool dummy = false)
        {
            UseStubs = dummy;
            if (!dummy)
            {
                File = new StreamWriter(fileName);
                FileIsOpen = true;
                WriteFunc = WriteNormal;
            }
            else
                WriteFunc = WriteStub;
        }
        public void Dispose()
        {
            if (UseStubs) return;
            if (!FileIsOpen) return;
            FileIsOpen = false;
            try
            {
                File.Flush();
                File.Close();
            }
            catch (ObjectDisposedException)
            {
            }
            File = null;
        }
        ~Logger()
        {
            Dispose();
        }

        private void WriteStub(string message) { }
        private void WriteNormal(string message)
        {
            if (!FileIsOpen)
                throw new NullReferenceException("File is closed");
            lock (File)
            {
                File.Write(message);
                File.Flush();
            }
        }
        private Action<string> WriteFunc { get; set; }

        public void WriteLine(string message)
        {
            var s = message + Environment.NewLine;
            if (OuptutTime)
                s = DateTime.Now + " - " + s;
            WriteFunc(s);
        }

    }
}
