﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExportDXF
{
    public static class Extensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static string ToReadableFormat(this TimeSpan ts)
        {
            var s = new StringBuilder();

            if (ts.TotalHours >= 1)
            {
                var hrs = ts.Hours + ts.Days * 24.0;

                s.Append(string.Format("{0}hrs ", hrs));
                s.Append(string.Format("{0}min ", ts.Minutes));
                s.Append(string.Format("{0}sec", ts.Seconds));
            }
            else if (ts.TotalMinutes >= 1)
            {
                s.Append(string.Format("{0}min ", ts.Minutes));
                s.Append(string.Format("{0}sec", ts.Seconds));
            }
            else
            {
                s.Append(string.Format("{0} seconds", ts.Seconds));
            }

            return s.ToString();
        }
    }
}