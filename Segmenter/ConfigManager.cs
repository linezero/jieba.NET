using System;
using System.IO;

namespace JiebaNet.Segmenter
{
    public class ConfigManager
    {
        private static string ConfigFileBaseDir
        {
            get
            {
                var configFileDir = "JiebaNet.Segmenter.Resources";
                return configFileDir;
            }
        }

        public static string MainDictFile
        {
            get { return $"{ConfigFileBaseDir}.dict.txt"; }
        }

        public static string ProbTransFile
        {
            get { return $"{ConfigFileBaseDir}.prob_trans.json"; }
        }

        public static string ProbEmitFile
        {
            get { return $"{ConfigFileBaseDir}.prob_emit.json"; }
        }

        public static string PosProbStartFile
        {
            get { return $"{ConfigFileBaseDir}.pos_prob_start.json"; }
        }

        public static string PosProbTransFile
        {
            get { return $"{ConfigFileBaseDir}.pos_prob_trans.json"; }
        }

        public static string PosProbEmitFile
        {
            get { return $"{ConfigFileBaseDir}.pos_prob_emit.json"; }
        }

        public static string CharStateTabFile
        {
            get { return $"{ConfigFileBaseDir}.char_state_tab.json"; }
        }
    }
}