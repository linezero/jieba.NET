using JiebaNet.Segmenter;
using System;
using System.Text;

namespace jieba.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            TestDemo test = new TestDemo();
            test.CutDemo();
            test.TokenizeDemo();
            Console.ReadKey();
        }
    }
}