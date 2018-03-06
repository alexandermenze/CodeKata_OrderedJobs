using System.Collections.Generic;
using System.IO;

namespace CodeKata_OrderedJobs.Source
{
    internal static class StringExtensions
    {
        public static IEnumerable<string> SplitToLines(this string src)
        {
            if (string.IsNullOrEmpty(src))
                yield break;

            using (var stringReader = new StringReader(src))
            {
                while (stringReader.Peek() != -1)
                    yield return stringReader.ReadLine();
            }
        }
    }
}