using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JiebaNet.Segmenter.Common
{
    public static class FileExtension
    {
        public static string ReadEmbeddedAllLine(string path)
        {
            return ReadEmbeddedAllLine(path, Encoding.UTF8);
        }

        public static string ReadEmbeddedAllLine(string path, Encoding encoding)
        {
            var provider = new EmbeddedFileProvider(typeof(FileExtension).GetTypeInfo().Assembly);
            var fileInfo = provider.GetFileInfo(path);
            using (var sr = new StreamReader(fileInfo.CreateReadStream(), encoding))
                return sr.ReadToEnd();
        }

        public static List<string> ReadEmbeddedAllLines(string path, Encoding encoding)
        {
            var provider = new EmbeddedFileProvider(typeof(FileExtension).GetTypeInfo().Assembly);
            var fileInfo = provider.GetFileInfo(path);
            var list = new List<string>();
            using (var streamReader = new StreamReader(fileInfo.CreateReadStream(), encoding))
            {
                string item;
                while ((item = streamReader.ReadLine()) != null)
                    list.Add(item);
            }

            return list;
        }

        public static List<string> ReadEmbeddedAllLines(string path)
        {
            return ReadEmbeddedAllLines(path, Encoding.UTF8);
        }
    }
}