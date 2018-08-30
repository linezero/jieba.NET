using Microsoft.Extensions.FileProviders;
using System;
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

        public static string ReadEmbeddedAllLine(string path,Encoding encoding)
        {
            var assembly = typeof(JiebaNet.Segmenter.JiebaSegmenter).GetTypeInfo().Assembly;
            Stream resourceStream = assembly.GetManifestResourceStream(path);
            using (var sr = new StreamReader(resourceStream, encoding))
            {
                return sr.ReadToEnd();
            }
        }

        public static List<string> ReadEmbeddedAllLines(string path, Encoding encoding)
        {
            var assembly = typeof(JiebaNet.Segmenter.JiebaSegmenter).GetTypeInfo().Assembly;
            Stream resourceStream = assembly.GetManifestResourceStream(path);
            List<string> list = new List<string>();
            using (StreamReader streamReader = new StreamReader(resourceStream, encoding))
            {
                string item;
                while ((item = streamReader.ReadLine()) != null)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<string> ReadEmbeddedAllLines(string path)
        {
            return ReadEmbeddedAllLines(path, Encoding.UTF8);
        }
    }
}
