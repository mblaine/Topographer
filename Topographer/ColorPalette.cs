using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Topographer
{
    public class ColorPalette
    {
        private static Dictionary<String, Color> table = null;

        private static void LoadTable()
        {
            table = new Dictionary<String, Color>();
            
            Regex linePattern = new Regex(@"^([0-9:,]+);([0-9a-fA-F]{6})\s*(?:#.*)?$");
            Regex idPattern = new Regex(@"^\d+(:?\:\d+)?$");

            String[] lines = File.ReadAllLines(String.Format("{0}{1}Blocks.txt",Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Path.DirectorySeparatorChar));

            foreach (String line in lines)
            {
                Match m = linePattern.Match(line);
                if (m.Groups.Count == 3)
                {
                    String[] ids = m.Groups[1].Value.Split(',');
                    foreach (String id in ids)
                    {
                        if (idPattern.IsMatch(id))
                            table.Add(id, Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(m.Groups[2].Value, 16))));
                    }
                }
                #if DEBUG
                else
                {
                    if(line.Trim().Length > 0)
                        throw new Exception(String.Format("Malformed line:\"{0}\"", line));
                }
                #endif
            }
        }

        public static Color Lookup(int block, int data)
        {
            if (table == null)
                LoadTable();

            String key = String.Format("{0}:{1}", block, data);

            if (table.ContainsKey(key))
                return table[key];
            else if(table.ContainsKey(block.ToString()))
                return table[block.ToString()];
            else
                return Color.Black;
        }
    }
}
