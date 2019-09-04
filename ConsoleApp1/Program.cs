using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Diagnostics;

class Solution
{

    // Complete the biggerIsGreater function below.
    static string biggerIsGreater(string w)
    {
        //Console.WriteLine(w);
        int lastInversion = -1;
        for(int i=w.Length-2;i>=0;i--)
        {
            if(w[i]<w[i+1])
            {
                lastInversion = i;
                break;
            }
        }
        if(lastInversion<0)
        {
            return "no answer";
        }
        StringBuilder sb = new StringBuilder();
        var remaining = w.Substring(lastInversion);
        sb.Append(w.Substring(0, lastInversion));
        var nextInLine = getNextInLine(w[lastInversion], remaining);
        sb.Append(nextInLine);
        sb.Append(getOrderedRemaining(remaining,nextInLine));
        var retval = sb.ToString();        
        return retval;
    }

    private static char[] getOrderedRemaining(string remaining,char nextInLine)
    {
        var counts = remaining.GroupBy(chr => chr).ToDictionary(grp => grp.Key, grp => grp.Count());
        counts[nextInLine]--;
        return counts.Keys.SelectMany(key => Enumerable.Range(0, counts[key]).Select(i => key)).OrderBy(chr => chr).ToArray();
    }

    private static char getNextInLine(char inversionChar, string remaining)
    {
        return remaining.Where(r => r > inversionChar).Min();
    }

    static void Main(string[] args)
    {
        //TextReader tr = new StreamReader(Console.OpenStandardInput());
        TextReader tr = new StringReader("1\r\nab");
        TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());

        int T = Convert.ToInt32(tr.ReadLine());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = tr.ReadLine();

            string result = biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
