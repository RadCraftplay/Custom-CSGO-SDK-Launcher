/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

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
public class PathFormatter
{
    //public static List<KeyValuePair<string, string>> Paths = new List<KeyValuePair<string, string>>();
    public static Dictionary<string, string> Paths = new Dictionary<string, string>();

    public static void Format(ref string Source)
    {
        List<SearchResult> res = Find(Source);
        int Length = Source.Length;

        foreach (SearchResult r in res)
        {
            string sr;
            Paths.TryGetValue(r.Result, out sr);
            Replace(ref Source, r, sr, Source.Length - Length);
        }
    }

    public static string Format(string Source)
    {
        string s = Source;
        Format(ref s);
        return s;
    }

    static List<SearchResult> Find(string Source)
    {
        List<SearchResult> result = new List<SearchResult>();
        SearchResult latest = new SearchResult();
        bool InsideExpr = false;

        for (int i = 0; i < Source.Length; i++)
        {
            if (Source[i] == '}')
            {
                InsideExpr = false;
                result.Add(latest);
            }

            if (InsideExpr)
            {
                latest.Result += Source[i];
                continue;
            }

            if (Source[i] == '{')
            {
                InsideExpr = true;

                latest = new SearchResult()
                {
                    Position = i
                };
            }
        }

        return result;
    }

    static void Replace(ref string Source, SearchResult result, string replacement, int Offset)
    {
        Source = Source.Remove(result.Position + Offset, result.Length);
        Source = Source.Insert(result.Position + Offset, replacement);
    }
}

class SearchResult
{
    public int Position;
    public string Result;

    public int Length
    {
        get
        {
            if (Result.Length == 0)
                return 0;
            else
                return Result.Length + 2;
        }
    }

    public SearchResult()
    {
        Result = string.Empty;
    }
}