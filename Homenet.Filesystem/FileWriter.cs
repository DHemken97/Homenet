using System.IO;
using System.Threading;

namespace Homenet.Filesystem
{
    public static class FileWriter
    {
        public static bool WriteToFile(string path, string value)
        {
            var attempt = 0;
            var hasWritten = false;
            while (attempt <= 5 && !hasWritten)
            {
                attempt++;
                hasWritten = StaticExtension.Try(() => File.WriteAllText(path, value));
                if (!hasWritten)
                    Thread.Sleep(1000);
            }

            return hasWritten;
        }
        public static bool AppendToFile(string path, string value)
        {
            var attempt = 0;
            var hasWritten = false;
            while (attempt <= 5 && !hasWritten)
            {
                attempt++;
                hasWritten = StaticExtension.Try(() => File.AppendAllText(path, value));
                if (!hasWritten)
                    Thread.Sleep(1000);
            }

            return hasWritten;
        }
    }
}
