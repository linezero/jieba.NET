using JiebaNet.Segmenter;
using JiebaNet.Segmenter.Common;
using System;
using System.Text;

namespace jieba.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var segmenter = new JiebaSegmenter();
            segmenter.LoadUserDict("userdict.txt");
            var segments = segmenter.Cut("我来到北京清华大学", cutAll: true);
            Console.WriteLine("【全模式】：{0}", string.Join("/ ", segments));

            segments = segmenter.Cut("我来到北京清华大学");  // 默认为精确模式
            Console.WriteLine("【精确模式】：{0}", string.Join("/ ", segments));

            segments = segmenter.Cut("他来到了网易杭研大厦");  // 默认为精确模式，同时也使用HMM模型
            Console.WriteLine("【新词识别】：{0}", string.Join("/ ", segments));

            segments = segmenter.CutForSearch("小明硕士毕业于中国科学院计算所，后在日本京都大学深造"); // 搜索引擎模式
            Console.WriteLine("【搜索引擎模式】：{0}", string.Join("/ ", segments));

            segments = segmenter.Cut("结过婚的和尚未结过婚的");
            Console.WriteLine("【歧义消除】：{0}", string.Join("/ ", segments));

            segments = segmenter.Cut("linezerodemo机器学习学习机器");
            Console.WriteLine("【用户字典】：{0}", string.Join("/ ", segments));

            //词频统计
            var s = "此领域探讨如何处理及运用自然语言。自然语言生成系统把计算机数据转化为自然语言。自然语言理解系统把自然语言转化为计算机程序更易于处理的形式。";
            var freqs = new Counter<string>(segmenter.Cut(s));
            foreach (var pair in freqs.MostCommon(5))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            Console.ReadKey();
        }
    }
}