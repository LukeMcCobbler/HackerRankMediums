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
class Solution
{
    // Complete the nonDivisibleSubset function below.
    static int nonDivisibleSubset(int k, int[] S)
    {
        return 3;
    }
    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        bool notInHr=true;

        TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());
        string rawNk="4 3";
        string[] nk = (notInHr?rawNk:Console.ReadLine()).Split(' ');
        int n = Convert.ToInt32(nk[0]);
        int k = Convert.ToInt32(nk[1]);
        string rawS="1 7 2 4";
        int[] S = Array.ConvertAll((notInHr?rawS:Console.ReadLine()).Split(' '), STemp => Convert.ToInt32(STemp));
        int result = nonDivisibleSubset(k, S);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}
