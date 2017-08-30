﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TitanBot.Util;

namespace System
{
    public static class StringUtils
    {
        public static string RemoveEnd(this string s, string remove)
        {
            if (s.EndsWith(remove, StringComparison.InvariantCultureIgnoreCase))
                return s.Substring(0, s.Length - remove.Length);
            return s;
        }

        public static string ToTitleCase(this string text)
            => new CultureInfo("en-GB", false).TextInfo.ToTitleCase(text);

        public static string RegexReplace(this string text, string pattern, MatchEvaluator evaluator)
            => Regex.Replace(text, pattern, evaluator);
        public static string RegexReplace(this string text, string pattern, string replacement)
            => Regex.Replace(text, pattern, replacement);
        public static string RegexReplace(this string text, string pattern, MatchEvaluator evaluator, RegexOptions options)
            => Regex.Replace(text, pattern, evaluator, options);
        public static string RegexReplace(this string text, string pattern, string replacement, RegexOptions options)
            => Regex.Replace(text, pattern, replacement, options);
        public static string RegexReplace(this string text, string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout)
            => Regex.Replace(text, pattern, replacement, options, matchTimeout);
        public static string RegexReplace(this string text, string pattern, MatchEvaluator evaluator, RegexOptions options, TimeSpan matchTimeout)
            => Regex.Replace(text, pattern, evaluator, options, matchTimeout);

        public static IEnumerable<(int From, int To)> GetBlockRanges(this string text)
        {
            bool isEscaped = false;
            bool isQuote = false;
            bool isArray = false;
            bool prevWasSpace = true;
            bool isFlag = false;
            int previousSplit = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (isEscaped)
                {
                    isEscaped = false;
                    continue;
                }
                switch (text[i])
                {
                    case '\\':
                        isEscaped = true;
                        break;
                    case '"':
                        isQuote = !isQuote;
                        break;
                    case ',':
                        isArray = true;
                        break;
                    case '-':
                        if (text.Length <= i + 1 || !"abcdefghijklmnopqrstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ-".Contains(text[i + 1]))
                            continue;
                        if (prevWasSpace && isFlag)
                        {
                            yield return (previousSplit, i - 1);
                            previousSplit = i;
                        }
                        if (prevWasSpace)
                            isFlag = true;
                        break;
                    case '\n':
                    case '\r':
                    case '\t':
                    case ' ':
                        if (!isArray && !isQuote)
                            prevWasSpace = true;
                        if (!isArray && !isQuote && !isFlag && (i + 1 == text.Length || text[i + 1] != ' '))
                        {
                            yield return (previousSplit, i);
                            previousSplit = i + 1;
                        }
                        break;
                    default:
                        isArray = false;
                        break;
                }
                prevWasSpace = prevWasSpace && (text[i] == ' ' || text[i] == '\n' || text[i] == '\r' || text[i] == '\t');
            }
            if (previousSplit != text.Length)
                yield return (previousSplit, text.Length);
        }

        private static string RemoveControls(this string text)
        {
            bool isEscaped = false;
            var builder = new StringBuilder();
            foreach (var c in text)
            {
                if (isEscaped)
                {
                    isEscaped = false;
                    builder.Append(c);
                    continue;
                }
                switch (c)
                {
                    case '\\':
                        isEscaped = true;
                        break;
                    case '"':
                        break;
                    default:
                        builder.Append(c);
                        break;
                }
            }

            return builder.ToString();
        }

        public static string[] BlockString(this string text, params (int From, int To)[] indexes)
        {
            var res = new List<string>();
            foreach (var block in indexes)
            {
                res.Add(text.Substring(block.From, block.To - block.From));
            }
            return res.ToArray();
        }

        private static IEnumerable<(int From, int To)> Squeeze(this IEnumerable<(int From, int To)> data, int maxLength, int position = -1)
        {
            if (maxLength == -1)
                maxLength = data.Count();
            if (maxLength == 0)
                yield break;
            position = (maxLength + position) % maxLength;
            var overflowAmount = Math.Max(1, data.Count() - maxLength + 1);
            for (int i = 0; i < data.Count(); i++)
            {
                if (i == position)
                {
                    var res = (data.Skip(i).First().From, data.Skip(i + overflowAmount - 1).First().To);
                    i += overflowAmount - 1;
                    yield return res;
                }
                else
                    yield return data.Skip(i).First();
            }
        }

        public static string[] SmartSplit(this string text, bool ignoreFlags, out (string Key, string Value)[] flags)
            => SmartSplit(text, null, null, ignoreFlags, out flags);
        public static string[] SmartSplit(this string text, int? maxLength, int? squeezePosition, bool ignoreFlags, out (string Key, string Value)[] flags)
        {
            var splitIndexes = text.GetBlockRanges().ToArray();
            var blocks = text.BlockString(splitIndexes);
            Func<string, bool> argCheck = (b => ignoreFlags || b.StartsWith("---") || !b.StartsWith("-") || b.TrimStart('-').Length == 0);
            var flagBlocks = blocks.SkipWhile(argCheck);
            var argBlocks = blocks.TakeWhile(argCheck);
            var argIndexes = splitIndexes.Take(argBlocks.Count());


            if (maxLength == null)
                argBlocks.Count();
            if (maxLength < 0)
                throw new ArgumentException("Cannot have negative block counts");

            var flagKeyValues = new List<(string Key, string Value)>();
            foreach (var block in flagBlocks)
            {
                var split = block.Split(new char[] { ' ' }, 2);
                if (block.StartsWith("--"))
                {
                    if (split.Length == 1)
                        flagKeyValues.Add((split[0].Substring(2), null));
                    else
                        flagKeyValues.Add((split[0].Substring(2), split[1]));
                }
                else if (block.StartsWith("-"))
                {
                    var flagCount = split[0].Substring(1).Length;
                    var flagValues = new string[flagCount];
                    flagValues[flagCount - 1] = split.Length == 2 ? split[1] : null;
                    flagKeyValues.AddRange(flagValues.Zip(split[0].Substring(1), (v, k) => (k.ToString(), v)));
                }
            }
            flags = flagKeyValues.ToArray();

            if (maxLength == 0)
                return new string[0];

            argIndexes = argIndexes.Squeeze(maxLength ?? -1, squeezePosition ?? -1);

            return text.BlockString(argIndexes.ToArray()).Select(b => b.RemoveControls()).ToArray();
        }

        public static string Tableify(this object[][] data, string cellFormat = "{0} ", string headerFormat = null)
        {
            var builder = new StringBuilder();
            data = data.ForceColumns();
            var maxWidth = data.Rotate().Select(c => c.Max(v => v?.ToString()?.Length ?? 0)).ToList();
            for (int row = 0; row < data.Length; row++)
            {
                for (int col = 0; col < data[row].Length; col++)
                {
                    if (row == 0 && headerFormat != null)
                        builder.Append(string.Format(headerFormat, data[row][col].ToString().PadRight(maxWidth[col])));
                    else
                        builder.Append(string.Format(cellFormat, (data[row][col]?.ToString() ?? "").PadRight(maxWidth[col])));
                }
                builder.Append("\n");
            }

            return builder.ToString();
        }
    }
}
