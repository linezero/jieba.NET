using JiebaNet.Segmenter.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiebaNet.Analyser
{
    public class IdfLoader
    {
        internal IDictionary<string, double> IdfFreq { get; set; }
        internal double MedianIdf { get; set; }

        public IdfLoader(IDictionary<string, double> idfFreq)
        {
            IdfFreq = idfFreq ?? new Dictionary<string, double>();
            MedianIdf = IdfFreq.Values.OrderBy(v => v).ToList()[IdfFreq.Count / 2];
        }

        public void SetNewPath(IDictionary<string, double> newIdfFreq)
        {
            IdfFreq = IdfFreq?.Union(newIdfFreq).ToDictionary(k => k.Key, v => v.Value) ?? newIdfFreq;
            MedianIdf = IdfFreq.Values.OrderBy(v => v).ToList()[IdfFreq.Count / 2];
        }
    }
}