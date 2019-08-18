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

    // Complete the queensAttack function below.
    private class coord { 
        public int r;
        public int c;
        public coord(int col,int row)
        {
            r=row;
            c=col;
        }

    }


    static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
    {
        var directions=new List<coord>(){
            new coord(0,1),//S
            new coord(1,1),//SE
            new coord(1,0),//E
            new coord(1,-1),//NE
            new coord(0,-1),//N
            new coord(-1,-1),//NW
            new coord(-1,0),//W
            new coord(-1,1)//SW
        };
        var obsCoords= obstacles.Select(obs => new coord(obs[1],obs[0]) ).ToList();
        var obsLookup=new Dictionary<int,HashSet<int>>();
        foreach(var obs in obsCoords)
        {
            if(!obsLookup.ContainsKey(obs.r))
            {
                obsLookup[obs.r]=new HashSet<int>();
            }
            obsLookup[obs.r].Add(obs.c);
        }
        int attackCount=0;
        foreach( var direction in directions )
        {
            var cursor=new coord(c_q+direction.c, r_q+direction.r);
            while(isValidSquare(cursor,n,obsLookup))
            {
                attackCount++;
                cursor.r+=direction.r;
                cursor.c+=direction.c;
            }
        }
        return attackCount;
    }

    private static bool isValidSquare(coord cursor, int n, Dictionary<int, HashSet<int>> obsLookup)
    {
        if(cursor.r<1||cursor.c<1||cursor.r>n||cursor.c>n)
        {
            return false;
        }
        if( obsLookup.ContainsKey(cursor.r)&&obsLookup[cursor.r].Contains(cursor.c))
        {
            return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        //var sampleInput = "5 3\n4 3\n5 5\n4 2\n2 3";
        var sampleInput = "1 0\n1 1";
        TextReader tr = new StringReader(sampleInput);
        TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());

        string[] nk = tr.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        string[] r_qC_q = tr.ReadLine().Split(' ');

        int r_q = Convert.ToInt32(r_qC_q[0]);

        int c_q = Convert.ToInt32(r_qC_q[1]);

        int[][] obstacles = new int[k][];

        for (int i = 0; i < k; i++)
        {
            obstacles[i] = Array.ConvertAll(tr.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
        }

        int result = queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
