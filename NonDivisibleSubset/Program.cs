﻿using System.CodeDom.Compiler;
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

class Result
{

    /*
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        var modBuckets = s.GroupBy(number => number % k).ToDictionary(grp => grp.Key, grp => grp.Count());
        Console.WriteLine(string.Join(",", modBuckets.Select(kvp => string.Format("{0}:{1}", kvp.Key, kvp.Value))));

        var retval = 0;
        foreach (var mod in modBuckets.Keys)
        {
            var modCount = modBuckets[mod];
            var complement = k - mod;
            var complementCount = modBuckets.ContainsKey(complement) ? modBuckets[complement] : 0;
            if (mod == complement || k == complement)
            {
                retval++;
            }
            else
            {
                if (modCount > complementCount)
                {
                    retval += modCount;
                }

            }
        }
        return retval;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
