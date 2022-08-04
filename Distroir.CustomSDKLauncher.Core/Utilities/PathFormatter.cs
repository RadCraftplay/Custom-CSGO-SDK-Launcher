/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * Example usage of formatter:
 * 
 * string source = "{GameBinDir}\\hammer.exe";
 * PathFormatter.Format(ref source);
 * MessageBox.Show(source);
 * //Example output: C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\bin\hammer.exe
 */
namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public static class PathFormatter
    {
        public static readonly Dictionary<string, string> Paths = new Dictionary<string, string>();

        public static String Format(string source)
        {
            var placeholders = FindPlaceholders(source);
            var length = source.Length;
            var output = source;

            foreach (var placeholder in placeholders)
            {
                if (Paths.TryGetValue(placeholder.Result, out var replacement))
                    output = Replace(output, placeholder, replacement, output.Length - length);
            }

            return output;
        }

        static List<SearchResult> FindPlaceholders(string source)
        {
            var result = new List<SearchResult>();
            var latest = new SearchResult();
            var insideExpr = false;

            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] == '}')
                {
                    insideExpr = false;
                    result.Add(latest);
                }

                if (insideExpr)
                {
                    latest.Result += source[i];
                    continue;
                }

                if (source[i] == '{')
                {
                    insideExpr = true;

                    latest = new SearchResult()
                    {
                        Position = i
                    };
                }
            }

            return result;
        }

        static string Replace(string source, SearchResult result, string replacement, int offset)
        {
            return source
                .Remove(result.Position + offset, result.Length)
                .Insert(result.Position + offset, replacement);
        }
    }

    internal class SearchResult
    {
        public int Position;
        public string Result;

        public int Length
        {
            get
            {
                if (Result.Length == 0)
                    return 0;
                
                return Result.Length + 2;
            }
        }

        public SearchResult()
        {
            Result = string.Empty;
        }
    }
}