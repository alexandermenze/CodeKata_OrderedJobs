using System.Collections.Generic;
using System.IO;

namespace CodeKata_OrderedJobs.Source
{
    internal static class StringExtensions
    {
        public static IEnumerable<string> SplitToLinesIgnoringEmpty(this string src)
        {
            if (string.IsNullOrEmpty(src))
                yield break;

            using (var stringReader = new StringReader(src))
            {
                string readString;
                while (stringReader.Peek() != -1 
                       && !string.IsNullOrEmpty(readString = stringReader.ReadLine()))
                {
                    yield return readString;
                }
            }
        }
    }
}