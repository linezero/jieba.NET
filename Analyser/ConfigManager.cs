using System.IO;

namespace JiebaNet.Analyser
{
    public class ConfigManager
    {
        // TODO: duplicate codes.
        public static string ConfigFileBaseDir => "Resources";

        public static string IdfFile => Path.Combine(ConfigFileBaseDir, "idf.txt");
    }
}