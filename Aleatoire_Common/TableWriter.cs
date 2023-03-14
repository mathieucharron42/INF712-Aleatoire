using System;
using System.Collections.Generic;
using System.Text;

namespace Aleatoire_Common
{
    public static class TableWriter
    {
        public static void ConsoleWrite(List<string> headers, List<List<string>> rows)
        {
            WriteTableLine(LineType.Top, headers);
            WriteTableContentRow(headers, headers);
            WriteTableLine(LineType.Middle, headers);
            foreach (List<string> row in rows)
            {
                WriteTableContentRow(headers, row);
            }
            WriteTableLine(LineType.Bottom, headers);
        }

        private enum LineType
        {
            Top,
            Middle,
            Bottom
        }

        private struct Corners
        {
            public char Left { get; set; }
            public char Middle { get; set; }
            public char Right { get; set; }
        }

        private const char kHorizontalChar = '─';
        private const char kVerticalChar = '│';
        private static Dictionary<LineType, Corners> kCornerChars = new Dictionary<LineType, Corners>()
        {
            { LineType.Top, new Corners() { Left = '┌', Middle='┬', Right = '┐'} },
            { LineType.Middle, new Corners() { Left = '├', Middle='┼', Right = '┤'} },
            { LineType.Bottom, new Corners() { Left = '└', Middle='┴', Right = '┘'} }
        };

        private static void WriteTableContentRow(List<string> headers, List<string> row)
        {
            //Header
            StringBuilder lineBuilder = new StringBuilder();
            for (int i = 0; i < headers.Count; ++i)
            {
                string header = headers[i];
                int columnWidth = GetColumnWidth(header);
                string content = row[i];
                string contentTrimmed = content.Substring(0, Math.Min(content.Length, columnWidth));
                lineBuilder.Append(kVerticalChar);
                lineBuilder.Append(contentTrimmed.PadRight(columnWidth));
            }
            lineBuilder.Append(kVerticalChar);
            Console.WriteLine(lineBuilder);
        }

        private static void WriteTableLine(LineType type, List<string> headers)
        {
            Corners coners = kCornerChars[type];
            StringBuilder lineBuilder = new StringBuilder();
            lineBuilder.Append(coners.Left);
            for (int i = 0; i < headers.Count; ++i)
            {
                string header = headers[i];
                int columnWidth = GetColumnWidth(header);
                string segment = new string(kHorizontalChar, columnWidth);
                lineBuilder.Append(segment);
                if (i != headers.Count - 1)
                {
                    lineBuilder.Append(coners.Middle);
                }
            }

            lineBuilder.Append(coners.Right);

            Console.WriteLine(lineBuilder.ToString());
        }

        private static int GetColumnWidth(string header)
        {
            const int kPadding = 2;
            return header.Length + kPadding * 2;
        }
    }
}
